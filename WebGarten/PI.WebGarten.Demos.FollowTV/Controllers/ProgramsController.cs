using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Demos.FollowTV.Views;
using System.Net;
using PI.WebGarten.Demos.FollowTV.Prog.Model;
using PI.WebGarten.Demos.FollowTV.Serie.Model;

namespace PI.WebGarten.Demos.FollowTV.Controllers
{
    class ProgramsController
    {
        private readonly SerieRepository _repo;

         public ProgramsController()
        {
            _repo = SerieLocator.Get();
        }
        
        [HttpCmd(HttpMethod.Get, "/programs")]
        public HttpResponse Get()
        {
            return new HttpResponse(200, new ProgsView(_repo.GetAllPrograms()));
        }

        [HttpCmd(HttpMethod.Post, "/programs")]
        public HttpResponse Post(IEnumerable<KeyValuePair<string, string>> content)
        {
            var name = content.Where(p => p.Key == "name").Select(p => p.Value).FirstOrDefault();
            if (name == null)
            {
                return new HttpResponse(HttpStatusCode.BadRequest);
            }
            var td = new ProgItem {Name = name};
           // _repo.Add(td);
            return new HttpResponse(HttpStatusCode.SeeOther).WithHeader("Location",ResolveUri.ForProgram(td));
        }
        
    }
}
