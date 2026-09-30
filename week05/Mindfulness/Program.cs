using System;

/*
 * EXCEEDING REQUIREMENTS
 * 1. Activity log: the program counts how many times each activity was completed
 *    and the total seconds spent on it (menu option 4). The log is saved to
 *    "activity_log.txt" and loaded again the next time the program starts.
 * 2. No repeated prompts/questions: random prompts and questions are not repeated
 *    until all of them have been used at least once in the session.
 * 3. Breathing animation: a bar grows while the user breathes in and shrinks
 *    while the user breathes out.
 */
class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog("activity_log.txt");

        // Created once so the "no repeats" lists last for the whole session.
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. View activity log");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathing.Run();
                    log.Record(breathing.GetName(), breathing.GetDuration());
                    break;
                case "2":
                    reflecting.Run();
                    log.Record(reflecting.GetName(), reflecting.GetDuration());
                    break;
                case "3":
                    listing.Run();
                    log.Record(listing.GetName(), listing.GetDuration());
                    break;
                case "4":
                    log.Display();
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please type 1, 2, 3, 4 or 5.");
                    Console.WriteLine("Press enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("Goodbye!");
    }
}