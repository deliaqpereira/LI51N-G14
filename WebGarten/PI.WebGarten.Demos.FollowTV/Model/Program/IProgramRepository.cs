using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowTV.Prog.Model
{
    interface IProgramRepository
    {
        IEnumerable<ProgItem> GetAll();
        ProgItem GetByName(string id);
        void Add(ProgItem td);
       
    }
}
