using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroup:IDisposable
    {
        IEnumerable<PageGroup> GetAllGroup();
        PageGroup GetPageGeoupByID(int id);
        bool InsertNewPageGroup(PageGroup pageGroup);
        bool UpdatePageGroup(PageGroup pageGroup);
        bool DeletePageGroup(int id);
        bool DeletePageGroup(PageGroup pageGroup);
        void Save();

        IEnumerable<ShowGroupViewModel> GetGroupForView();

    }
}
