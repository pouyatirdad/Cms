using DataLayer;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class NewsController : Controller
    {
        MYCmsContext db = new MYCmsContext();
        private IPageGroup pageGroupRepository;
        private IPage pageRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
        }
       
        public ActionResult ShowGroups()
        {
            return PartialView(pageGroupRepository.GetGroupForView());
        }
        public ActionResult ShowGroupMenu()
        {
            return PartialView(pageGroupRepository.GetAllGroup());
        }
        public ActionResult TopNews()
        {
            return PartialView(pageRepository.TopNews());
        }
        public ActionResult LatesNews()
        {
            return PartialView(pageRepository.Last());
        }
        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepository.GetAllPage());
        }
        [Route("group/{id}/{title}")]
        public ActionResult ShowGroupByID(int id,string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupID(id));
        }
    }
}