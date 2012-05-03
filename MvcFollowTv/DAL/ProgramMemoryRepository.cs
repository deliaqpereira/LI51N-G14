using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.RepositoryInterface;
using Domain.DomainEntity;

namespace DAL
{
    public class ProgramMemoryRepository : IProgramRepository
    {
        private readonly IDictionary<string, ProgItem> _repo = new Dictionary<string, ProgItem>();


        public IEnumerable<ProgItem> GetAll()
        {
            return _repo.Values;
        }

        public void Add(ProgItem p)
        {
            _repo.Add(p.Name, p);
        }

        public ProgItem GetByName(string name)
        {
            ProgItem p = null;
            _repo.TryGetValue(name, out p);
            return p;
        }

       

    }
}
