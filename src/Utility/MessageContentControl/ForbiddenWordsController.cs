public sealed class ForbiddenWordsController
{
  private string[] ForbiddenWords { get; set; }

  public ForbiddenWordsController(string[] _forbiddenWords)
  {
    ForbiddenWords = _forbiddenWords;
  }

  public bool ContainsForbiddenWord(string line) => ForbiddenWords.Any(word => line.Contains(word));
  public string? GetFirstForbiddenWord(string line)
  {
    string? _word = null;
    foreach (string word in ForbiddenWords)
    {
      /* Todo: extend StringComparison to support other checkings */
      if (line.Contains(word, StringComparison.OrdinalIgnoreCase))
      {
        _word = word; break;
      }

    }

    return _word;
  }

  public bool HasForbiddenWord(string line) => ForbiddenWords.Any();
}