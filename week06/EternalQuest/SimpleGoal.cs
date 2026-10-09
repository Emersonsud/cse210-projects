using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal was already completed. No extra points.");
            return 0;
        }

        _isComplete = true;
        Console.WriteLine($"Congratulations! You have earned {Points} points!");
        return Points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName}|{Description}|{Points}|{_isComplete}";
    }
}
