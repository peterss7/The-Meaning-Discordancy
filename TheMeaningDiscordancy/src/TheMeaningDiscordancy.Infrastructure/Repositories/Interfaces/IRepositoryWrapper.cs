using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMeaningDiscordancy.Infrastructure.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    IItemRepository ItemRepository { get; }
    ITagRepository TagRepository { get; }
    void save();
}
