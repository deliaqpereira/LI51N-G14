using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.HttpContent.Html;
using PI.WebGarten.Demos.FollowTV.Episodes.Model;

namespace PI.WebGarten.Demos.FollowTV.Views
{
    class EpisodeView : HtmlDoc
    {
        public EpisodeView(string name, Episode p)
            :base("Episodes",
                H1(Text("Episode")),
                P(Text(p.Title)),
                A(ResolveUri.ForEpisodes(name, p), "Episodes list")
                ){}
    }
}
