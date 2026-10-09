using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private const int PointsPerLevel = 1000;

    private readonly string[] _titles =
    {
        "Sleepy Egg", "Curious Hatchling", "Brave Squire", "Ninja Apprentice",
        "Ninja Unicorn", "Valiant Knight", "Mighty Champion", "Eternal Legend"
    };

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = 0;
            }

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: Console.WriteLine("Keep going on your Eternal Quest. Goodbye!"); break;
                default: Console.WriteLine("Invalid option. Please try again."); break;
            }
        }
    }

    private int GetLevel() => (_score / PointsPerLevel) + 1;

    private string GetTitle()
    {
        int index = Math.Min(GetLevel() - 1, _titles.Length - 1);
        return _titles[index];
    }

    public void DisplayPlayerInfo()
    {
        int nextLevelAt = GetLevel() * PointsPerLevel;
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {GetLevel()} - {GetTitle()}  (next level at {nextLevelAt} points)");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        Console.WriteLine("Your goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        Console.Write("Which type of goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int type) || type < 1 || type > 4)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = AskInt(type == 4
            ? "How many points do you lose each time you slip? "
            : "What is the amount of points associated with this goal? ");

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                int target = AskInt("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = AskInt("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case 4:
                _goals.Add(new NegativeGoal(name, description, points));
                break;
        }

        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create one first.");
            return;
        }

        ListGoalNames();
        int number = AskInt("Which goal did you accomplish? ");

        if (number < 1 || number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int levelBefore = GetLevel();
        int earned = _goals[number - 1].RecordEvent();
        _score = Math.Max(0, _score + earned);   // score never drops below zero

        Console.WriteLine($"You now have {_score} points.");

        if (GetLevel() > levelBefore)
        {
            Console.WriteLine($"*** LEVEL UP! You are now level {GetLevel()}: {GetTitle()}! ***");
        }
        else if (GetLevel() < levelBefore)
        {
            Console.WriteLine($"You dropped back to level {GetLevel()}. Keep fighting!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        List<Goal> loaded = new List<Goal>();

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = CreateGoalFromString(lines[i]);
            if (goal != null)
            {
                loaded.Add(goal);
            }
        }

        _score = int.TryParse(lines[0], out int savedScore) ? savedScore : 0;
        _goals = loaded;
        Console.WriteLine("Goals loaded.");
    }

    // Small "factory" method: rebuilds a goal object from a saved line.
    private Goal CreateGoalFromString(string line)
    {
        string[] halves = line.Split(":", 2);
        if (halves.Length < 2) return null;

        string type = halves[0];
        string[] p = halves[1].Split("|");

        try
        {
            switch (type)
            {
                case "SimpleGoal":
                    return new SimpleGoal(p[0], p[1], int.Parse(p[2]), bool.Parse(p[3]));
                case "EternalGoal":
                    return new EternalGoal(p[0], p[1], int.Parse(p[2]));
                case "ChecklistGoal":
                    return new ChecklistGoal(p[0], p[1], int.Parse(p[2]),
                        int.Parse(p[4]), int.Parse(p[3]), int.Parse(p[5]));
                case "NegativeGoal":
                    return new NegativeGoal(p[0], p[1], int.Parse(p[2]));
            }
        }
        catch (Exception)
        {
            Console.WriteLine($"Skipping a corrupted line: {line}");
        }

        return null;
    }

    private int AskInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Please enter a whole number: ");
        }
        return value;
    }
}
