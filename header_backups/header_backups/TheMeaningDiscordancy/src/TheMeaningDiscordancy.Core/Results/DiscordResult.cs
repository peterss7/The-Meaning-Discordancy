namespace TheMeaningDiscordancy.Core.Results;

public class DiscordResult
{
    public bool Success { get; set; }

    public string? Message { get; set; } = "";

    public bool HasError { get; set; }

    public List<DiscordError> Errors { get; set; } = new();

    public static DiscordResult Ok(string? message = null) =>
        new DiscordResult { Success = true, Message = message };

    public static DiscordResult Fail(string message) =>
        new DiscordResult { Success = false, Message = message };
}

public class DiscordResult<T> : DiscordResult
{
    public T? Value { get; set; }

    public static DiscordResult<T> Ok(T data, string? message = null) =>
        new DiscordResult<T> { Success = true, Value = data, Message = message };

    public static new DiscordResult<T> Fail(string message) =>
        new DiscordResult<T> { Success = false, Message = message };
}