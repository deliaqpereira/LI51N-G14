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

        private ProgramLogic _progLogic = new ProgramLogic();

        //
        // GET: /Programs/
        public ActionResult Index()
        {
            IEnumerable<ProgItem> allProgs = _progLogic.GetAll();

            return View(allProgs);
        }

    }
}
