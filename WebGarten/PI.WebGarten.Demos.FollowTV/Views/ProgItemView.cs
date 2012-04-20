using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.HttpContent.Html;
using PI.WebGarten.Demos.FollowTV.Prog.Model;

namespace PI.WebGarten.Demos.FollowTV.Views
{
    class ProgItemView : HtmlDoc
    {
        public ProgItemView(ProgItem p)
            :base("Programs",
                H1(Text("Program")),
                P(Text(p.Name)),//P(A(ResolveUri.ForEpisodes(p.Name),"Episodes list")),
                A(ResolveUri.ForPrograms(),"Program list")
                ){}
    }
}
