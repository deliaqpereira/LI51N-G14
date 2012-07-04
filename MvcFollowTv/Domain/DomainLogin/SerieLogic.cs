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

        public int TotalPages(int recordsPerPage)
        {
            var nr = _repository.GetAllPrograms().Count<ProgItem>() / (double)recordsPerPage;
            return (int)Math.Ceiling(nr);
        }

        public IEnumerable<ProgItem> GetInterval(int page, int recordsPerPage)
        {
            int skip = (page) * recordsPerPage;
            return _repository.GetAllPrograms().Skip(skip).Take(recordsPerPage);
        }


        public IEnumerable<ProgItem> GetSearchResult(string filter)
        {
            filter = filter.ToUpper();

            IEnumerable<ProgItem> query=_repository.GetAllPrograms().Where(c => c.Name.ToUpper().StartsWith(filter)).ToList<ProgItem>();
           
            return query;
            
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


        public void InsertSerie(Serie s)
        {

            foreach (Episode e in s.repo)
                Add(s.progItem, e);


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

            ///////////////////////////////////////////////////////////////////////////
            ProgItem p2 = new ProgItem { Name = "Agente Dupla", Descr = "Serie Policial" };
            Episode e12 = new Episode { Title = "Episodio1- Agente Dupla" };
            Episode e22 = new Episode { Title = "Episodio2- Agente Dupla" };
            Episode e32 = new Episode { Title = "Episodio3- Agente Dupla" };

            Add(p2, e12);
            Add(p2, e22);
            Add(p2, e32);

            ProgItem p3 = new ProgItem { Name = "Chicago Code", Descr = "Serie Policial" };
            Episode e13 = new Episode { Title = "Episodio1- Chicago Code" };
            Episode e23 = new Episode { Title = "Episodio2- Chicago Code" };
            Episode e33 = new Episode { Title = "Episodio3- Chicago Code" };

            Add(p3, e13);
            Add(p3, e23);
            Add(p3, e33);

            //////////////////////////////////////////////////////////////////////
            ProgItem p4 = new ProgItem { Name = "Agente Dupla", Descr = "Serie Policial" };
            Episode e14 = new Episode { Title = "Episodio1- Agente Dupla" };
            Episode e24 = new Episode { Title = "Episodio2- Agente Dupla" };
            Episode e34 = new Episode { Title = "Episodio3- Agente Dupla" };

            Add(p4, e14);
            Add(p4, e24);
            Add(p4, e34);

            ProgItem p5 = new ProgItem { Name = "Hawai Forca Especial", Descr = "Serie Policial" };
            Episode e15 = new Episode { Title = "Episodio1- Hawai Forca Especial" };
            Episode e25 = new Episode { Title = "Episodio2- Hawai Forca Especial" };
            Episode e35 = new Episode { Title = "Episodio3- Hawai Forca Especial" };

            Add(p5, e15);
            Add(p5, e25);
            Add(p5, e35);

            //////////////////////////////////////////////////////////////////////
            ProgItem p6 = new ProgItem { Name = "Family Guy", Descr = "Animação" };
            Episode e16 = new Episode { Title = "Episodio1- Family Guy" };
            Episode e26 = new Episode { Title = "Episodio2- Family Guy" };
            Episode e36 = new Episode { Title = "Episodio3- Family Guy" };

            Add(p6, e16);
            Add(p6, e26);
            Add(p6, e36);

            ProgItem p7 = new ProgItem { Name = "American Dad", Descr = "Animação" };
            Episode e17 = new Episode { Title = "Episodio1- American Dad" };
            Episode e27 = new Episode { Title = "Episodio2- American Dad" };
            Episode e37 = new Episode { Title = "Episodio3- American Dad" };

            Add(p7, e17);
            Add(p7, e27);
            Add(p7, e37);

            ////////////////////////////////////////////////////////////////////////
            ProgItem p8 = new ProgItem { Name = "Agente Dupla-2ª Temporada", Descr = "Serie Policial" };
            Episode e18 = new Episode { Title = "Episodio1- Agente Dupla - 2ª Temporada" };
            Episode e28 = new Episode { Title = "Episodio2- Agente Dupla - 2ª Temporada" };
            Episode e38 = new Episode { Title = "Episodio3- Agente Dupla - 2ª Temporada" };

            Add(p8, e18);
            Add(p8, e28);
            Add(p8, e38);
        }
    }
}
