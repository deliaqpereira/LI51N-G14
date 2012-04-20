using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowTV.User.Model
{
    public class User
    {
        public string Nome { get; private set; }
        public int Id { get; private set; }
        public string Password { get; private set; }
        public string[] Role { get; private set; }

        public User(String name, String pass, String[] type)
        {
            Nome = name;
            Password = pass;
            Role = type;
        }

        public void setId(int id)
        {
            Id = id;
        }
    }
}
