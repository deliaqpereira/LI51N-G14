using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.HttpContent.Html;
using PI.WebGarten.Demos.FollowTV.Prog.Model;
using PI.WebGarten.Demos.FollowTV.Episodes.Model;

namespace PI.WebGarten.Demos.FollowTV.Views
{
    class EpisodesView:HtmlDoc
    {
        public EpisodesView(string name, IEnumerable<Episode> e)
            : base("Episodes",
                H1(Text("Episode list")),
                Ul(
                    e.Select(td => Li(A(ResolveUri.ForEpisodes(name,td), td.Title))).ToArray()
                    ),
                H2(Text("Create a new Episode")),
                Form("post", "/programs/{name}/episodes",
                    Label("title", "Tilte: "), InputText("title")
                    )
                ) { }
        
    }
}
