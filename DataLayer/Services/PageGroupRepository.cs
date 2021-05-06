using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Services
{
    public class PageGroupRepository : IPageGroup
    {
        MYCmsContext db;
        public PageGroupRepository(MYCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<PageGroup> GetAllGroup()
        {
            return db.pageGroups;
        }

        public PageGroup GetPageGeoupByID(int id)
        {
            return db.pageGroups.Find(id);
        }

        public bool InsertNewPageGroup(PageGroup pageGroup)
        {
            try
            {
                db.pageGroups.Add(pageGroup);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdatePageGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = System.Data.Entity.EntityState.Modified;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool DeletePageGroup(int id)
        {
            try
            {
                var group = GetPageGeoupByID(id);
                DeletePageGroup(group);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePageGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = System.Data.Entity.EntityState.Deleted;
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
