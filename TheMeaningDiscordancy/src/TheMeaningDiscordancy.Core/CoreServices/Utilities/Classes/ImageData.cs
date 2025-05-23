namespace TheMeaningDiscordancy.Core.CoreServices.Utilities.Classes;

public class ImageData
{
    public string? ImageName { get; set; }
    public string? ImagePath { get; set; }
    public ImageData() { }
    public ImageData(string? imageName, string? imagePath)
    {
        ImageName = imageName;
        ImagePath = imagePath;
    }
}
