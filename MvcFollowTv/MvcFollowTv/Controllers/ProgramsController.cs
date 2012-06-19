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
            return View();
        }

        //
        // GET: /Programs/
        public ActionResult IndexNormal()
        {
            IEnumerable<ProgItem> allProgs = MvcApplication._progLogic.GetAllPrograms();

            return View(allProgs);
        }

        //
        // GET: /Programs/
        public ActionResult IndexWithPage(int? page, int? pagesize)
        {
            if (pagesize == null)
            {
                pagesize = 5;
            }
            if (page == null)
            {
                return RedirectToAction("IndexWithPage", new { page = "0", pagesize });
            }

            ViewBag.lastpage = MvcApplication._progLogic.TotalPages((int)pagesize);
            FillViewBag((int)page, (int)pagesize);
            if (ViewBag.lastpage < page)
                return RedirectToAction("IndexWithPage", new { page = ViewBag.lastpage, pagesize });
            if (page < 0)
                return RedirectToAction("IndexWithPage", new { page = "0", pagesize });

            return View(MvcApplication._progLogic.GetInterval((int)page, (int)pagesize));

        }

        private void FillViewBag(int page, int pagesize)
        {
            ViewBag.pagesize = pagesize;
            ViewBag.lastpage--;
            ViewBag.nextpage = page < ViewBag.lastpage ? (page + 1) : ViewBag.lastpage;
            ViewBag.prevpage = page <= 0 ? -1 : (page - 1);
            ViewBag.page = page;
        }

        public ActionResult IntervalPage(int page, int pagesize)
        {
            return View("_PageRecords", MvcApplication._progLogic.GetInterval(page, pagesize));
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

        public ActionResult CreateEpisode(string name)
        {
            User u = MvcApplication._userLogic.GetByNickName(User.Identity.Name);
            Serie s = MvcApplication._suggest.GetSerie(u, name);

            ViewBag.Index = s.progItem.Name;
            return View();
        }

        [HttpPost]
        public ActionResult CreateEpisode(string name, Episode e)
        {
           // p.UsrCreate = User.Identity.Name;
           // User u = MvcApplication._userLogic.GetByNickName(User.Identity.Name);

            //actualizar o repositorio de propostas
            if (e.Title == null)
                e = null;

            //MvcApplication._suggest.Add(u, p, e);

            return RedirectToAction("ListProposal");
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
