using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal was already completed. No extra points.");
            return 0;
        }

        _amountCompleted++;
        int earned = Points;

        if (IsComplete())
        {
            earned += _bonus;
            Console.WriteLine($"Goal finished! You earned {Points} points plus a {_bonus} point BONUS!");
        }
        else
        {
            Console.WriteLine($"Congratulations! You have earned {Points} points!");
        }

        return earned;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName}|{Description}|{Points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}
