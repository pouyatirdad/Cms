using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Cms.Controllers
{
    public class LoginController : Controller
    {
        private ILogin loginRepository;
        MYCmsContext db=new MYCmsContext();
        public LoginController()
        {
            loginRepository = new LoginRepository(db);
        }
        // GET: Login
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel login,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                if (loginRepository.IsExist(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return  Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName", "کاربر یافت نشد");
                }
            }

            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}