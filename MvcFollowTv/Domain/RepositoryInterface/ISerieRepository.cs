using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DomainEntity;

namespace Domain.RepositoryInterface
{
    public interface ISerieRepository
    {
        IEnumerable<IEpisodeRepository> GetAll();
        IEnumerable<ProgItem> GetAllPrograms();
        IEnumerable<Episode> GetAllEpisodesFrom(string name);
        IEpisodeRepository GetByProgram(ProgItem p);
        void Add(ProgItem p, Episode e);
        ProgItem GetProgramByName(string name);
    }
}
