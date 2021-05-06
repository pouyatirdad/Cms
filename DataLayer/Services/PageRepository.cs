using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPage
    {
        MYCmsContext db;
        public PageRepository(MYCmsContext context)
        {
            this.db = context;

        }
        public IEnumerable<Page> GetAllPage()
        {
            return db.pages;
        }

        public Page GetPageByID(int id)
        {
            return db.pages.Find(id);
        }

        public bool InsertNewPage(Page Page)
        {
            try
            {
                db.pages.Add(Page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdatePage(Page Page)
        {
            try
            {
                db.Entry(Page).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeletePage(int id)
        {
            try
            {
                var page = GetPageByID(id);
                DeletePage(page);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePage(Page Page)
        {
            try
            {
                db.Entry(Page).State = System.Data.Entity.EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

       

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
