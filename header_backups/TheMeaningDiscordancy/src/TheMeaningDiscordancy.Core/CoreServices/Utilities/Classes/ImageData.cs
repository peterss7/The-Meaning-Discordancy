// Copyright © 2025 Steven Peterson
// All rights reserved.  
// 
// No part of this code may be copied, modified, distributed, or used  
// without explicit written permission from the author.
// 
// For licensing inquiries or collaboration opportunities:
// 
// GitHub: https://github.com/peterss7  
// LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/

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
