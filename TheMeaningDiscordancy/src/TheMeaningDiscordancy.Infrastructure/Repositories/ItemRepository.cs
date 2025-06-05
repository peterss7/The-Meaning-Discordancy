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

using Microsoft.Extensions.Logging;
using TheMeaningDiscordancy.Infrastructure.Data;
using TheMeaningDiscordancy.Infrastructure.Models.Entities;
using TheMeaningDiscordancy.Infrastructure.Repositories.Base;
using TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

namespace TheMeaningDiscordancy.Infrastructure.Repositories;

public class ItemRepository : BaseRepository<ItemEfc>, IItemRepository
{
    public ItemRepository(DiscordContext context,
        ILogger<IRepositoryWrapper> logger) 
        :  base(context, logger)
    {
    }
}
