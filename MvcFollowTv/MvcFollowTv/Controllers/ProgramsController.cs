using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.DomainLogin;
using Domain.DomainEntity;

namespace MvcFollowTv.Controllers
{
    public class ProgramsController : Controller
    {

        private SerieLogic _progLogic = new SerieLogic();

        //
        // GET: /Programs/
        public ActionResult Index()
        {
            IEnumerable<ProgItem> allProgs = _progLogic.GetAllPrograms();

            return View(allProgs);
        }

        public ActionResult Episodes(string id)
        {

            Serie serie = _progLogic.GetSerieByName(id);

            return View(serie);
        }

        public ActionResult Details(string id, string title)
        {
            Episode p = _progLogic.GetCurrentEpisode(id, title);

            return View(p);
        }

        public ActionResult Edit(string id)
        {

            Serie serie = _progLogic.GetSerieByName(id);

            return View(serie);
        }

    }
}
