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

namespace TheMeaningDiscordancy.Core.Results;

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error InvalidInput = new(StatusCodes.Status400BadRequest.ToString(), "Input was invalid.");
    public static readonly Error NullInput = new(StatusCodes.Status400BadRequest.ToString(), "Input was null or empty.");
    public static readonly Error ExceptionError = new(StatusCodes.Status500InternalServerError.ToString(), "An internal server error occurred.");
    public static readonly Error NullImageResult = new Error(StatusCodes.Status404NotFound.ToString(), "Image found was null.");
    public static readonly Error NotFound = new Error(StatusCodes.Status404NotFound.ToString(), "Entity not found.");
}
