using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageComment:IDisposable
    {
        IEnumerable<PageComment> GetAllCommentByID(int id);
        bool AddNewCommnet(PageComment cm);
    }
}
