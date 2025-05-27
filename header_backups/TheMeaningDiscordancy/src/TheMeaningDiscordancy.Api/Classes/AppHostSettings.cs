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

namespace TheMeaningDiscordancy.Api.Classes;

public class AppHostSettings
{
    public string Scheme { get; set; } = "http";
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 5286;
}
