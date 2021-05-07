using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPage:IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageByID(int id);
        bool InsertNewPage(Page Page);
        bool UpdatePage(Page Page);
        bool DeletePage(int id);
        bool DeletePage(Page Page);
        void Save();

        IEnumerable<Page> TopNews(int num = 4);
        IEnumerable<Page> Slider();
        IEnumerable<Page> Last(int num=4);
        IEnumerable<Page> ShowPageByGroupID(int id);
    }
}
