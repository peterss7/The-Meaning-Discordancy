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

namespace TheMeaningDiscordancy.Core.Models.Errors;

public class DiscordError
{
    public BaseDiscordError? Error { get; set; }
    public string? Message { get; set; }
    public DiscordError() { }

    public DiscordError(BaseDiscordError error, string message)
    {
        Error = error;
        Message = message;
    }
}
