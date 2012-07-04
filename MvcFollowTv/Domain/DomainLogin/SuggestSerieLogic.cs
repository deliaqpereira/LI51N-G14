using System.Collections.Generic;
using Domain.RepositoryInterface;
using Domain.DomainEntity;
using DomainLocator;


namespace Domain.DomainLogin
{
    public class SuggestSerieLogic
    {
        private  IDictionary<User, ISerieRepository> _proposta = new Dictionary<User, ISerieRepository>();
        private  IUserRepository _repoUser = RepositoryFactory.GetInstanceUser<IUserRepository>();

        public SuggestSerieLogic()
        {
            //FillRepo();
        }

        public void FillRepo()
        {
            ProgItem p = new ProgItem { Name = "CSI-Miami_sugestao", Descr = "Serie Policial - Sugestao" };
            User u = _repoUser.GetByNickName("delita");

            if (u == null)
            {
                u = new User();
                u.Nickname = "delita";
                u.Password = "12345";
            }

            Add(u, p, null);
        }

        public IEnumerable<ProgItem> GetAllPrograms(User u)
        {
            ISerieRepository _serie;
            _proposta.TryGetValue(u, out _serie);
            return _serie.GetAllPrograms();
        }

        public IEnumerable<Episode> GetAllEpisodesFrom(User u, string name)
        {
            ISerieRepository _serie;
            _proposta.TryGetValue(u, out _serie);
            return _serie.GetAllEpisodesFrom(name);
        }

        public Serie GetSerie(User u, string name)
        {
            ISerieRepository _serie;
            _proposta.TryGetValue(u, out _serie);

            Serie s;

            s = new Serie { progItem = _serie.GetProgramByName(name), repo = _serie.GetAllEpisodesFrom(name) };

            return s;
        }

        public void Remove(User u, Serie s)
        {
           Serie serie = GetSerie(u, s.progItem.Name);
           _proposta.Remove(u);
        }

        public void Add(User user, ProgItem prog, Episode e)
        {
          //  user = _repoUser.GetByNickName(user.Nickname);
            ISerieRepository _repo;

            _proposta.TryGetValue(user, out _repo);

            if (_repo == null)
            {
                _repo = RepositoryFactory.GetInstanceSerie<ISerieRepository>();

                _repo.Add(prog, e);

                _proposta.Add(user, _repo);
            }
            else
            {
                ProgItem _prog = _repo.GetProgramByName(prog.Name);
                if (_prog == null)
                {
                    _repo.Add(_prog, e);
                }
                else
                {
                    _prog.Descr = prog.Descr;
                    _prog.UsrCreate = prog.UsrCreate;

                    _repo.Add(_prog, e);

                }
            }
        }
    }
}
