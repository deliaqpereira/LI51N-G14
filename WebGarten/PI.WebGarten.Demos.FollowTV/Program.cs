namespace PI.WebGarten.Demos.FollowTV
{
    using System.Diagnostics;

    using PI.WebGarten.Demos.FollowTV.Controllers;
    using PI.WebGarten.MethodBasedCommands;
    using PI.WebGarten.Demos.FollowTV.Prog.Model;
    using PI.WebGarten.Demos.FollowTV.Serie.Model;
    using PI.WebGarten.Demos.FollowTV.Episodes.Model;

    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
           // var repo = ProgramLocator.Get();
           // repo.Add(new ProgItem { Name = "CSI-Miami", DtIni = new System.DateTime(2012, 03, 01), DtFim = new System.DateTime(2012, 06, 01) });
            ProgItem p = new ProgItem { Name = "CSI-Miami", DtIni = new System.DateTime(2012, 03, 01), DtFim = new System.DateTime(2012, 06, 01) };
            Episode e1 = new Episode {Title = "Episodio1"};
            Episode e2 = new Episode {Title = "Episodio2"};
            Episode e3 = new Episode {Title = "Episodio3"};

            var repoSerie = SerieLocator.Get();
            repoSerie.Add(p, e1);
            repoSerie.Add(p, e2);
            repoSerie.Add(p, e3);

            var host = new HttpListenerBasedHost("http://localhost:8080/");
            host.Add(DefaultMethodBasedCommandFactory.GetCommandsFor(
                typeof(ProgramsController),
                typeof(ProgramController)));
            host.OpenAndWaitForever();

            /*var repo = ToDoRepositoryLocator.Get();
            repo.Add(new ToDo {Description = "Learn HTTP better"});
            repo.Add(new ToDo { Description = "Learn HTML 5 better"});
            
            var host = new HttpListenerBasedHost("http://localhost:8080/");
            host.Add(DefaultMethodBasedCommandFactory.GetCommandsFor(
                typeof(ToDosController),
                typeof(ToDoController)));
            host.OpenAndWaitForever();
             * */
        }
    }
}
