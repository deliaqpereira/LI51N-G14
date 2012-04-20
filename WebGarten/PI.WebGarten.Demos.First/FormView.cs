namespace PI.WebGarten.Demos.First
{
    using PI.WebGarten.HttpContent.Html;

    internal class FormView : HtmlDoc
    {
        public FormView()
            :base("Form",
                H1(Text("Opera��o")),
                Form())
        { }

        public FormView(int res)
            : base("T�tulo",
                H1(Text("Opera��o")),
                H2(Text("O resultado � "+res)),
                Form()
                )
        { }

        public FormView(string msg)
            : base("T�tulo",
                H1(Text("Opera��o")),
                H2(Text(msg)),
                Form()
                )
        { }

        private static IWritable Form()
        {
            return 
                Form("post","/calc",
                    Label("a","a") ,InputText("a"),
                    Label("b","b") ,InputText("b"),
                    InputSubmit("Submeter"));
            
        }
    }
}