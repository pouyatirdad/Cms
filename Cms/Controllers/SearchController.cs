using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class SearchController : Controller
    {

        private IPage pageRepositor;

        MYCmsContext db = new MYCmsContext();
        public SearchController()
        {
            pageRepositor = new PageRepository(db);
        }

        // GET: Search
        public ActionResult Index(string q)
        {

            ViewBag.name = q;
            return View(pageRepositor.Search(q));
        }
    }
}