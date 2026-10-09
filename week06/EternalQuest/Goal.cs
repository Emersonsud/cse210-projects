using System;

// Base class: holds the data and behavior shared by every kind of goal.
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    protected string ShortName => _shortName;
    protected string Description => _description;
    protected int Points => _points;

    // Records one event and returns the points earned (can be negative or zero).
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    // Text shown in the goal list, e.g. "[ ] Read (Scriptures)".
    public virtual string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_shortName} ({_description})";
    }

    // Text used to save the goal to a file: "Type:field|field|...".
    public abstract string GetStringRepresentation();
}
