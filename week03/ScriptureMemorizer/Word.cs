using System;

/// <summary>
/// Represents a single word in a scripture. A word knows its own text
/// and whether it is currently hidden (shown as underscores) or not.
/// </summary>
public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    /// <summary>
    /// Returns the text to display for this word: the word itself if
    /// visible, or a string of underscores matching its length if hidden.
    /// Punctuation attached to the word (e.g. "God," or "life.") is kept,
    /// and only the letters/digits are replaced so punctuation still shows.
    /// </summary>
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        char[] chars = _text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            if (char.IsLetterOrDigit(chars[i]))
            {
                chars[i] = '_';
            }
        }
        return new string(chars);
    }
}