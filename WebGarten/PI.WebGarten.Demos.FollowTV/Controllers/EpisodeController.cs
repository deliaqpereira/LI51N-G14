using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.MethodBasedCommands;
using System.Net;
using PI.WebGarten.Demos.FollowTV.Views;
using PI.WebGarten.Demos.FollowTV.Episodes.Model;


namespace PI.WebGarten.Demos.FollowTV.Controllers
{
    class EpisodeController
    {
        private readonly IEpisodeRepository _repo;
        public EpisodeController()
        {
            _repo = EpisodeRepositoryLocator.Get();
        }

        [HttpCmd(HttpMethod.Get, "/Programs/{name}/{title}")]
        public HttpResponse Get(string title)
        {
            var td = _repo.GetByTitle(title);
            return td == null ? new HttpResponse(HttpStatusCode.NotFound) : new HttpResponse(200, new EpisodeView(title,td));
        }
    }
}
