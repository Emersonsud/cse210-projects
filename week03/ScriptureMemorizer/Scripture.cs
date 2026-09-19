using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a full scripture: a reference plus the words of its text.
/// Knows how to hide random words and render itself for display.
/// </summary>
public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private static readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => new Word(w))
            .ToList();
    }

    /// <summary>
    /// Hides up to numberToHide words that are not already hidden.
    /// (Stretch challenge: only selects from words that are not yet
    /// hidden, rather than allowing an already-hidden word to be
    /// picked again, so each call to Hide() makes real progress.)
    /// </summary>
    public void HideRandomWords(int numberToHide)
    {
        List<Word> candidates = _words.Where(w => !w.IsHidden()).ToList();

        int toHide = Math.Min(numberToHide, candidates.Count);
        for (int i = 0; i < toHide; i++)
        {
            int index = _random.Next(candidates.Count);
            candidates[index].Hide();
            candidates.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{wordsText}";
    }
}