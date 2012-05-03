using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLocator
{
    public class RepositoryFactory
    {
        public static T GetInstance<T>()
        {
            Type t = Config.ProgramRepositoryTypeName;
            return (T)Activator.CreateInstance(t);
        }
    }
}
