using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.RepositoryInterface;
using Domain.DomainEntity;
using DomainLocator;

namespace Domain.DomainLogin
{
    public class ProgramLogic
    {
        private IProgramRepository _repository = RepositoryFactory.GetInstance<IProgramRepository>();

        public ProgramLogic()
        {
            FillRepo();
        }

        public IEnumerable<ProgItem> GetAll()
        {
            return _repository.GetAll();
        }

        public ProgItem GetById(string name)
        {
            return _repository.GetByName(name);
        }

        public void Add(ProgItem td)
        {
            _repository.Add(td);
        }

        public void FillRepo()
        {
            ProgItem p = new ProgItem { Name = "CSI-Miami", Descr = "Serie Policial" };
            Add(p);
        }
    }
}
