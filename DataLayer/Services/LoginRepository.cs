using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepository : ILogin
    {
        private MYCmsContext db;
        public LoginRepository(MYCmsContext context)
        {
            db = context;
        }

        public bool IsExist(string UserName, string Password)
        {
            return db.logins.Any(n => n.UserName == UserName && n.Password == Password);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
