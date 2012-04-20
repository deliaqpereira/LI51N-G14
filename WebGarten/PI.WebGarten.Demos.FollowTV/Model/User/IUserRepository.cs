using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowTV.User.Model
{
    interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(String id);
        void Add(User user);
    }
}
