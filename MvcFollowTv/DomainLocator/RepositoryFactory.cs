using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLocator
{
    public class RepositoryFactory
    {
        public static T GetInstanceProgram<T>()
        {
            Type t = Config.ProgramRepositoryTypeName;
            return (T)Activator.CreateInstance(t);
        }

        public static T GetInstanceSerie<T>()
        {
            Type t = Config.SerieRepositoryTypeName;
            return (T)Activator.CreateInstance(t);
        }

        public static T GetInstanceUser<T>()
        {
            Type t = Config.UserRepositoryTypeName;
            return (T)Activator.CreateInstance(t);
        }
    }
}
