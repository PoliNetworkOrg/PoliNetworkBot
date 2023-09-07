namespace PoliNetwork.Utility.MessageContentControl;

public sealed class ForbiddenWordsController
{
    private string[] ForbiddenWords { get; set; }

    public ForbiddenWordsController(string[] forbiddenWords)
    {
        ForbiddenWords = forbiddenWords;
    }

    public bool ContainsForbiddenWord(string line) => ForbiddenWords.Any(line.Contains);

    public string? GetFirstForbiddenWord(string line) =>
        ForbiddenWords.FirstOrDefault(word => line.Contains(word, StringComparison.OrdinalIgnoreCase));


    public bool HasForbiddenWord(string line) => ForbiddenWords.Any();
}