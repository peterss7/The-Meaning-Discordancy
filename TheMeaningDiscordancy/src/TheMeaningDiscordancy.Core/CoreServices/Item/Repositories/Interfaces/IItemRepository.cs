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

using TheMeaningDiscordancy.Core.CoreServices.Item.Models.Entities;
using TheMeaningDiscordancy.Core.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Core.CoreServices.Item.Repositories.Interfaces;

public interface IItemRepository : IDiscordRepository<ItemEfc>
{
}
