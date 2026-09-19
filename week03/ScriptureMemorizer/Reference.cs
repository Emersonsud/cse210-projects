using System;

/// <summary>
/// Represents the reference of a scripture (e.g. "John 3:16" or
/// "Proverbs 3:5-6"). Supports both a single verse and a verse range.
/// </summary>
public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verse;
    private readonly int _endVerse;

    // Single verse constructor, e.g. new Reference("John", 3, 16)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }

    // Verse range constructor, e.g. new Reference("Proverbs", 3, 5, 6)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText()
    {
        if (_endVerse > _verse)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        return $"{_book} {_chapter}:{_verse}";
    }
}