using Lot.IBLL;
using Lot.Model;
using System;
using System.Web.Mvc;

namespace Lot.UI.Controllers
{
    public class HomeController : Controller
    {
        public IUserService userService { get; set; }

        public ActionResult Index()
        {
            ViewBag.Message = "欢迎使用财务模块";
            return View();
        }

        public ActionResult Top()
        {
            ViewBag.UserName = "超级管理员";
            ViewBag.AvailableBalance = "8888.00";
            return View();
        }

        public ActionResult Left()
        {
            return View();
        }

        public ActionResult Right()
        {
            return View();
        }

        public ActionResult AddUser(FormCollection form)
        {
            USERINFO user = new USERINFO();
            //重点看这句，对Bll层的调用
            //IUserService userService = new UserService();
            user.ID = Convert.ToInt32(form["id"]);
            user.NAME = form["name"];
            user.AGE = Convert.ToInt32(form["age"]);
            userService.AddEntity(user);
            if (user == null)
            {
                return View("Contact");
            }
            else
            {
                return View("About");
            }
        }
    }
}