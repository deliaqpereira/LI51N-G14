using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Demos.FollowTV.Serie.Model;
using PI.WebGarten.MethodBasedCommands;
using PI.WebGarten.Demos.FollowTV.Views;
using System.Net;
using PI.WebGarten.Demos.FollowTV.Episodes.Model;

namespace PI.WebGarten.Demos.FollowTV.Controllers
{
    class EpisodesController
    {
        private readonly SerieRepository _repo;

        public EpisodesController()
        {
            _repo = SerieLocator.Get();
        }
        
        [HttpCmd(HttpMethod.Get, "/programs/{name}")]
        public HttpResponse Get(string name)
        {

            return new HttpResponse(200, new EpisodesView(name,_repo.GetAllEpisodesFrom(name)));
        }

        [HttpCmd(HttpMethod.Post, "/programs/{name}")]
        public HttpResponse Post(IEnumerable<KeyValuePair<string, string>> content)
        {
            var title = content.Where(p => p.Key == "title").Select(p => p.Value).FirstOrDefault();
            if (title == null)
            {
                return new HttpResponse(HttpStatusCode.BadRequest);
            }
            var td = new Episode { Title = title };
           // _repo.Add(td);
            return new HttpResponse(HttpStatusCode.SeeOther).WithHeader("Location",ResolveUri.ForEpisodes(title, td));
        }
    }
}
