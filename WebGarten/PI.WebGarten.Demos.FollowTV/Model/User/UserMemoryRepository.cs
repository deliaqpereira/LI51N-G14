using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowTV.User.Model
{
    public class UserMemoryRepository : IUserRepository
    {
        private static readonly IDictionary<String, User> _repoUser = new Dictionary<String, User>();
        private static int _cid = 1;

        public IEnumerable<User> GetAll()
        {
            return _repoUser.Values;
        }

        public User GetById(String id)
        {
            User user = null;
            _repoUser.TryGetValue(id, out user);
            return user;
        }

        public void Add(User user)
        {
            user.setId(_cid);
            _repoUser.Add(user.Nome, user);
        }

        public IDictionary<String, User> Get()
        {
            return _repoUser;
        }
    }
}
