using System;
using System.Collections.Generic;
using System.Threading;

// Base class: holds everything shared by all activities
// (name, description, duration, start/end messages, spinner and countdown).
public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private static Random _random = new Random();

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = AskForDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % frames.Count;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();
            Console.Write(text);
            Thread.Sleep(1000);
            for (int j = 0; j < text.Length; j++)
            {
                Console.Write("\b \b");
            }
        }
    }

    // Returns a random item and does not repeat any item until all of them
    // have been used once (refills the "remaining" list when it is empty).
    protected static string TakeRandom(List<string> all, List<string> remaining)
    {
        if (remaining.Count == 0)
        {
            remaining.AddRange(all);
        }

        int index = _random.Next(remaining.Count);
        string item = remaining[index];
        remaining.RemoveAt(index);
        return item;
    }

    private int AskForDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                return seconds;
            }

            Console.WriteLine("Please enter a whole number greater than 0.");
        }
    }
}
