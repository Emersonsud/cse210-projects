using System;
using System.Collections.Generic;

/*
 * ============================================================
 *  Exceeding the requirements
 * ============================================================
 * 1) Word.GetDisplayText() only masks the letters/digits of a word,
 *    so trailing punctuation (commas, periods) still shows through
 *    the underscores - it looks more like real scripture text while
 *    it's being hidden.
 *
 * 2) Scripture.HideRandomWords() implements the stretch challenge:
 *    it only chooses from words that are not already hidden, so
 *    every keypress makes real progress instead of possibly
 *    "re-hiding" a word that's already gone.
 *
 * 3) The program works with a small library of scriptures (see
 *    _library below) instead of just one. Each time the program
 *    starts, it picks a random scripture from the library to
 *    practice, so repeated runs give some variety.
 * ============================================================
 */
class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = BuildLibrary();
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        const int wordsToHidePerRound = 3;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.Write("Press enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(wordsToHidePerRound);
        }
    }

    private static List<Scripture> BuildLibrary()
    {
        return new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart, and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."),
        };
    }
}