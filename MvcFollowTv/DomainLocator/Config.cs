using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainLocator
{
    class Config
    {
        public static Type ProgramRepositoryTypeName
        {
            get
            {
                return Type.GetType("DAL.ProgramMemoryRepository,DAL");
            }
        }
    }
}
