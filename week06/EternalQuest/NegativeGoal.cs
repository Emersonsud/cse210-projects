using System;

// Extra creativity: a "bad habit" goal. Recording it makes you LOSE points.
public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int penalty)
        : base(name, description, Math.Abs(penalty))
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"Oh no! A bad habit slipped in. You lost {Points} points. Don't give up!");
        return -Points;
    }

    // Never complete (you can always slip again).
    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[!] {ShortName} ({Description}) -- Penalty: -{Points} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{ShortName}|{Description}|{Points}";
    }
}
