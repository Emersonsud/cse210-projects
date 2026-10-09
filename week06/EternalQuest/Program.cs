using System;

// EXCEEDING REQUIREMENTS (W06 Eternal Quest):
// 1. Leveling system: every 1000 points raises your level, with a fun title
//    (from "Sleepy Egg" up to "Eternal Legend") and a LEVEL UP message.
// 2. Negative goals (NegativeGoal class): bad habits that make you LOSE points
//    when recorded. The score never drops below zero.
// 3. The player's level and title are shown on the main menu next to the score.
// 4. Robust input: invalid numbers are re-asked, and corrupted lines in a save
//    file are skipped instead of crashing the program.
// 5. Save/load handles all four goal types, including checklist progress.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to the Eternal Quest! ===");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
