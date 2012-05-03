using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DomainEntity;

namespace Domain.RepositoryInterface
{
    public interface IProgramRepository
    {
        IEnumerable<ProgItem> GetAll();
        ProgItem GetByName(string id);
        void Add(ProgItem td);
    }
}
