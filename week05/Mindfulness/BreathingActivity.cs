using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Breathe("Breathe in...", 4, true, endTime);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Breathe("Breathe out...", 6, false, endTime);
        }

        DisplayEndingMessage();
    }

    // Shows the message and a bar that grows (breathing in)
    // or shrinks (breathing out) over the given number of seconds.
    private void Breathe(string message, int seconds, bool grow, DateTime endTime)
    {
        int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
        seconds = Math.Min(seconds, remaining);

        if (seconds <= 0)
        {
            return;
        }

        int width = 30;
        int delay = seconds * 1000 / width;

        Console.WriteLine(message);

        if (grow)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write("=");
                Thread.Sleep(delay);
            }
        }
        else
        {
            Console.Write(new string('=', width));
            for (int i = 0; i < width; i++)
            {
                Thread.Sleep(delay);
                Console.Write("\b \b");
            }
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}
