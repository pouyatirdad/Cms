using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageComment
    {
        MYCmsContext db;
        public PageCommentRepository(MYCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<PageComment> GetAllCommentByID(int id)
        {
            var findedCm = db.pageComments.Where(n => n.PageID == id);
            return findedCm;
        }
        public bool AddNewCommnet(PageComment cm)
        {
            try
            {

                db.pageComments.Add(cm);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
