using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowTV.Serie.Model
{
    class SerieLocator
    {
        private readonly static SerieRepository Repo = new SerieRepository();

        public static SerieRepository Get()
        {
            return Repo;
        }
    }
}
