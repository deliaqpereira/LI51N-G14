using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowTV.Prog.Model
{
    class ProgramLocator
    {
        private readonly static ProgramMemoryRepository Repo = new ProgramMemoryRepository();

        public static ProgramMemoryRepository Get()
        {
            return Repo;
        }
    }
}
