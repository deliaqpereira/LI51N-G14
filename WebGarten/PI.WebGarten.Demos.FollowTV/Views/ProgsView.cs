namespace PI.WebGarten.Demos.FollowTV.Views
{
    using System.Collections.Generic;
    using System.Linq;

    using PI.WebGarten.HttpContent.Html;
    using PI.WebGarten.Demos.FollowTV.Prog.Model;


    class ProgsView: HtmlDoc
    {
        public ProgsView(IEnumerable<ProgItem> p)
            : base("Programs",
                H1(Text("Program list")),
                Ul(
                    p.Select(td => Li(A(ResolveUri.ForProgram(td), td.Name))).ToArray()
                    ),
                H2(Text("Create a new Program")),
                Form("post", "/programs",
                    Label("name", "Name: "), InputText("name")
                    )
                ) { }
        
    }
}
