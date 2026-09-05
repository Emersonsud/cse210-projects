using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Student Profile: Emerson dos Santos");
        Console.Write("Enter your grade percentage (0-100): ");
        int percentage = int.Parse(Console.ReadLine());

        string letter = "";

        if (percentage >= 90) { letter = "A"; }
        else if (percentage >= 80) { letter = "B"; }
        else if (percentage >= 70) { letter = "C"; }
        else if (percentage >= 60) { letter = "D"; }
        else { letter = "F"; }

        Console.WriteLine($"Your letter grade is: {letter}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Keep trying! Better luck next time.");
        }
    }
}
