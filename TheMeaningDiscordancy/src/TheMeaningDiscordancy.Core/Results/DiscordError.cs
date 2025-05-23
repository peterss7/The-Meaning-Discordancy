namespace TheMeaningDiscordancy.Core.Results;

public class DiscordError
{
    public Error? Error { get; set; }
    public string? Message { get; set; }
    public DiscordError() { }

    public DiscordError(Error error, string message) 
    {
        Error = error;
        Message = message;
    }
}
