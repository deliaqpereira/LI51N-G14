using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowTV.User.Model
{
    class UserLocator
    {
        private readonly static IUserRepository RepoUser = new UserMemoryRepository();
        public static IUserRepository Get()
        {
            return RepoUser;
        }

        public static User findUser(String name)
        {
            return RepoUser.GetById(name);
        }
    }
}
