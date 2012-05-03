using System;
using System.Collections.Generic;
using Domain.DomainEntity;

namespace Domain.RepositoryInterface
{
    public interface IEpisodeRepository
    {
        IEnumerable<Episode> GetAll();
        Episode GetByTitle(string title);
        void Add(Episode td);
    }
}
