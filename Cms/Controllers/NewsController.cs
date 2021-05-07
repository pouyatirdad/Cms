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
        private IPageComment pageCommentRepository;

        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
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
        public ActionResult ShowGroupByID(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupID(id));
        }
        [Route("news/{id}")]
        public ActionResult ShowNewsByID(int id)
        {
            var FindedNews = pageRepository.GetPageByID(id);
            return View(FindedNews);
        }
        public ActionResult AddComment(int id,string name,string email,string comment)
        {
            PageComment addcm = new PageComment()
            {
                CreateDate=DateTime.Now,
                PageID=id,
                Comment=comment,
                Show=true,
                Name=name,
                Email=email,
                
            };

            pageCommentRepository.AddNewCommnet(addcm);

            return PartialView("ShowCommnetByPageID",pageCommentRepository.GetAllCommentByID(id));
        }
        public ActionResult ShowCommnetByPageID(int id)
        {
            return PartialView(pageCommentRepository.GetAllCommentByID(id));
        }
    }
}