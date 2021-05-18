﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Services;

namespace Cms.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private IPage pageRepository;

        private IPageGroup pageGroupRepository;

        private MYCmsContext db = new MYCmsContext();

        public PagesController()
        {
            pageRepository = new PageRepository(db);
            pageGroupRepository = new PageGroupRepository(db);
        }

        // GET: Admin/Pages
        public ActionResult Index()
        {

            return View(pageRepository.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroup(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Views,Image,Slider,CreateDate,Tags")] Page page, HttpPostedFileBase UploadIMG)
        {
            if (ModelState.IsValid)
            {
                page.Views = 0;
                page.CreateDate = DateTime.Now;


                if (UploadIMG != null)
                {
                    page.Image = Guid.NewGuid() + Path.GetExtension(UploadIMG.FileName);
                    UploadIMG.SaveAs(Server.MapPath("/PagesImages/" + page.Image));
                }


                pageRepository.InsertNewPage(page);
                pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(pageRepository.GetAllPage(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroup(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Views,Image,Slider,CreateDate,Tags")] Page page, HttpPostedFileBase UploadIMG)
        {
            if (ModelState.IsValid)
            {

                if (UploadIMG != null)
                {
                    if (page.Image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PagesImages/" + page.Image));
                    }

                    page.Image = Guid.NewGuid() + Path.GetExtension(UploadIMG.FileName);
                    UploadIMG.SaveAs(Server.MapPath("/PagesImages/" + page.Image));
                }

                pageRepository.UpdatePage(page);
                pageRepository.Save();

                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(pageRepository.GetAllPage(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetPageByID(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var page = pageRepository.GetPageByID(id);
            if (page.Image != null)
            {
                System.IO.File.Delete(Server.MapPath("/PagesImages/" + page.Image));
            }

            pageRepository.DeletePage(page);
            pageRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageRepository.Dispose();
                pageGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
