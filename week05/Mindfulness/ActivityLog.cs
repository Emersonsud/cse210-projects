using System;
using System.Collections.Generic;
using System.IO;

// Keeps track of how many times each activity was done and for how many seconds.
// The log is loaded from and saved to a text file (one line per activity: name|count|seconds).
public class ActivityLog
{
    private string _path;
    private Dictionary<string, int> _counts = new Dictionary<string, int>();
    private Dictionary<string, int> _seconds = new Dictionary<string, int>();

    public ActivityLog(string path)
    {
        _path = path;
        Load();
    }

    public void Record(string activityName, int seconds)
    {
        if (!_counts.ContainsKey(activityName))
        {
            _counts[activityName] = 0;
            _seconds[activityName] = 0;
        }

        _counts[activityName]++;
        _seconds[activityName] += seconds;
        Save();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("Activity log");
        Console.WriteLine("------------");

        if (_counts.Count == 0)
        {
            Console.WriteLine("No activities have been completed yet.");
        }

        foreach (string name in _counts.Keys)
        {
            Console.WriteLine($"{name}: {_counts[name]} time(s), {_seconds[name]} seconds in total");
        }

        Console.WriteLine();
        Console.Write("Press enter to go back to the menu. ");
        Console.ReadLine();
    }

    private void Load()
    {
        if (!File.Exists(_path))
        {
            return;
        }

        foreach (string line in File.ReadAllLines(_path))
        {
            string[] parts = line.Split('|');

            if (parts.Length == 3 && int.TryParse(parts[1], out int count) && int.TryParse(parts[2], out int seconds))
            {
                _counts[parts[0]] = count;
                _seconds[parts[0]] = seconds;
            }
        }
    }

    private void Save()
    {
        List<string> lines = new List<string>();

        foreach (string name in _counts.Keys)
        {
            lines.Add($"{name}|{_counts[name]}|{_seconds[name]}");
        }

        File.WriteAllLines(_path, lines);
    }
}
