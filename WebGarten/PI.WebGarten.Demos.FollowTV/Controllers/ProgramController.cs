using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.MethodBasedCommands;
using System.Net;
using PI.WebGarten.Demos.FollowTV.Views;
using PI.WebGarten.Demos.FollowTV.Prog.Model;


namespace PI.WebGarten.Demos.FollowTV.Controllers
{
    class ProgramController
    {
        private readonly IProgramRepository _repo;
        public ProgramController()
        {
            _repo = ProgramLocator.Get();
        }

        [HttpCmd(HttpMethod.Get, "/Programs/{name}")]
        public HttpResponse Get(string name)
        {
            var td = _repo.GetByName(name);
            return td == null ? new HttpResponse(HttpStatusCode.NotFound) : new HttpResponse(200, new ProgItemView(td));
        }
    }
}
