﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.RepositoryInterface;
using Domain.DomainEntity;

namespace DAL
{
    class UserMemoryRepository : IUserRepository
    {
        private readonly IDictionary<string, User> _repoUser = new Dictionary<string, User>();


        public IEnumerable<User> GetAll()
        {
            return _repoUser.Values;
        }

        public User GetByNickName(string nickname)
        {
            User user = null;
            if (nickname != null)
                _repoUser.TryGetValue(nickname, out user);
            return user;
        }

        public void Add(User user)
        {
            User u = GetByNickName(user.Nickname);
            if (u == null)
                _repoUser.Add(user.Nickname, user);
            else
            {
                u.Password = user.Password;
                u.Image = user.Image;
                u.Email = user.Email;
            }
        }

        public bool Remove(string nickname)
        {
            if (nickname != null)
            {
                _repoUser.Remove(nickname);
                return true;
            }
            return false;
        }
    }
}
