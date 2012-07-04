using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.RepositoryInterface;
using DomainLocator;
using Domain.DomainEntity;

namespace Domain.DomainLogin
{
    public class UserLogic
    {
        private IUserRepository _repository = RepositoryFactory.GetInstanceUser<IUserRepository>();

        public UserLogic()
        {
            FillRepo();
        }

        public void FillRepo()
        {
            //adicionar user
            _repository.Add(new User { Nickname = "delita", Password = "12345", Email = "herf@isel.pt", Role = new[] { "Admin" }, activated = true });
            _repository.Add(new User { Nickname = "nicola", Password = "12345", Email = "nicola@isel.pt", Role = new[] { "User" }, activated = true });
            _repository.Add(new User { Nickname = "ping", Password = "12345", Email = "ping@isel.pt", Role = new[] { "Hold" }, activated = false });
            _repository.Add(new User { Nickname = "pong", Password = "12345", Email = "pong@isel.pt", Role = new[] { "Coord" }, activated = true });
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetByNickName(string name)
        {
            return _repository.GetByNickName(name);
        }

        public void Add(User u)
        {
            _repository.Add(u);
        }

        public bool Remove(string nickname)
        {
           return _repository.Remove(nickname);
        }
    }
}
