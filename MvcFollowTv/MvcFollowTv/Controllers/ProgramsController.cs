using System.Collections.Generic;
using System.Web.Mvc;
using Domain.DomainEntity;
using MvcFollowTv;

namespace MvcFollowTv.Controllers
{
    public class ProgramsController : Controller
    {

        //private SerieLogic _progLogic = new SerieLogic();
        //private SuggestSerieLogic _suggest = new SuggestSerieLogic();

        //
        // GET: /Programs/
        public ActionResult Index()
        {
            IEnumerable<ProgItem> allProgs = MvcApplication._progLogic.GetAllPrograms();

            return View(allProgs);
        }

        public ActionResult Episodes(string id)
        {

            Serie serie = MvcApplication._progLogic.GetSerieByName(id);

            return View(serie);
        }

        public ActionResult Details(string id, string title)
        {
            Episode p = MvcApplication._progLogic.GetCurrentEpisode(id, title);

            return View(p);
        }

        public ActionResult Edit(string id)
        {

            Serie serie = MvcApplication._progLogic.GetSerieByName(id);

            return View(serie);
        }

        [HttpPost]
        public ActionResult Edit(Serie p)
        {

           // Serie serie = _progLogic.GetSerieByName(id);
            UpdateModel<Serie>(p);

            return RedirectToAction("Edit");
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProgItem p, Episode e)
        {
            p.UsrCreate = User.Identity.Name;
            User u = MvcApplication._userLogic.GetByNickName(User.Identity.Name);

            //actualizar o repositorio de propostas
            if (e.Title == null)
                e = null;

            MvcApplication._suggest.Add(u, p, e);

            return RedirectToAction("ListProposal");
        }

        public ActionResult CreateEpisode()
        {
            return View();
        }

        public ActionResult ListProposal()
        {
            User u = MvcApplication._userLogic.GetByNickName(User.Identity.Name);
            IEnumerable<ProgItem> allProgs = MvcApplication._suggest.GetAllPrograms(u);

            return View(allProgs);

        }

        public ActionResult EpisodesProposal(string id)
        {
            User u = MvcApplication._userLogic.GetByNickName(User.Identity.Name);

            Serie serie =MvcApplication._suggest.GetSerie(u, id);

            return View(serie);
        }

    }
}
