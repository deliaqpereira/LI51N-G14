using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.RepositoryInterface;
using DomainLocator;
using Domain.DomainEntity;

namespace Domain.DomainLogin
{
    public class SerieLogic
    {
        private ISerieRepository _repository = RepositoryFactory.GetInstanceSerie<ISerieRepository>();

        public SerieLogic()
        {
            FillRepo();
        }

        public Serie GetSerieByName(string name)
        {
            Serie s = null;
            ProgItem p = GetCurrentProgram(name);

            if (p != null)
            {
                s = new Serie { progItem = p, repo = GetAllEpisodesFrom(name) };
                return s;
            }

            return s;
        }

        public IEnumerable<IEpisodeRepository> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ProgItem> GetAllPrograms()
        {
            return _repository.GetAllPrograms();
        }

        public ProgItem GetCurrentProgram(string name)
        {
            return _repository.GetProgramByName(name);
        }

        public Episode GetCurrentEpisode(string name, string title)
        {
            foreach (Episode e in GetAllEpisodesFrom(name))
            {
                if (e.Title.Equals(title))
                    return e;
            }

            return null;

            
        }

        public IEnumerable<Episode> GetAllEpisodesFrom(string name)
        {
            return _repository.GetAllEpisodesFrom(name);
        }

        public IEpisodeRepository GetByProgram(ProgItem p)
        {
            return _repository.GetByProgram(p);
        }

        public void Add(ProgItem p, Episode e)
        {
            _repository.Add(p, e);                
        }

        public void FillRepo()
        {
            ProgItem p = new ProgItem { Name = "CSI-Miami" , Descr="Serie Policial"};
            Episode e1 = new Episode { Title = "Episodio1- CSI" };
            Episode e2 = new Episode { Title = "Episodio2- CSI" };
            Episode e3 = new Episode { Title = "Episodio3- CSI" };

            Add(p, e1);
            Add(p, e2);
            Add(p, e3);

            ProgItem p1 = new ProgItem { Name = "Dexter", Descr = "Serie Policial" };
            Episode e11 = new Episode { Title = "Episodio1- Dexter" };
            Episode e21 = new Episode { Title = "Episodio2- Dexter" };
            Episode e31 = new Episode { Title = "Episodio3- Dexter" };

            Add(p1, e11);
            Add(p1, e21);
            Add(p1, e31);
        }
    }
}
