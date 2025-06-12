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

using TheMeaningDiscordancy.Core.Models.Errors;
using TheMeaningDiscordancy.Core.Models.Utilities;

namespace TheMeaningDiscordancy.Core.Services.Interfaces;

public interface IImageUtilityService
{
    Task<DiscordResult<ImageData>> SaveImageAsync(IFormFile file);
    string GetImageContentType(string path);
}
