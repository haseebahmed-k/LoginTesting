using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testingLogin.Models;

namespace testingLogin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDBcontext db = new OurDBcontext())
            {
                return View(db.userAccount.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserAccount account) {
            if (ModelState.IsValid) {
                using (OurDBcontext db = new OurDBcontext()) {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + " successfully registered ";
            }
            return View();
        }


        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (OurDBcontext db = new OurDBcontext())
            {
                if (user.userName != null && user.userName != ""  && user.Password != null && user.Password != "" && user.ConfirmPassword != null && user.ConfirmPassword != "")
                {

                    try
                    {
                        var usr = db.userAccount.Single(u => u.userName == user.userName && u.Password == user.Password);

                        if (usr != null)
                        {
                            Session["userID"] = usr.UserId.ToString();
                            Session["UserName"] = usr.userName.ToString();
                            return RedirectToAction("LoggedIn");

                        }
                        else
                        {
                            ModelState.AddModelError("", "UserName or password is wrong.");
                        }

                    }
                    catch (System.InvalidOperationException)
                    {
                        ModelState.AddModelError("", "UserName or password is wrong.");

                    }

                }

            }
            return View();
        }

        public ActionResult LoggedIn() {
            if(Session["userId"] != null)
                    {
                    return View();
                }
                else
{
                    return RedirectToAction("Login");
                }
        }

    }




}