using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.DomainEntity;

namespace Domain.RepositoryInterface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByNickName(String nickname);
        void Add(User user);
        Boolean Remove(String nickname);
    }
}
