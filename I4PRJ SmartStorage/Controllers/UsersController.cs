using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace I4PRJ_SmartStorage.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ApplicationSignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
        }

        public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        // GET: User
        public ActionResult Index()
        {
            var usersInDb = db.Users.Select(userInDb => new RegisterViewModel
            {
                Username = userInDb.UserName,
                Firstname = userInDb.Firstname,
                Middlename = userInDb.Middlename,
                Lastname = userInDb.Lastname,
                Email = userInDb.Email,
                PhoneNumber = userInDb.PhoneNumber,
            }).ToList();
            return View(usersInDb);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    Lastname = model.Lastname
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }

            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userInDb = db.Users.SingleOrDefault(u => u.UserName == id);
            if (userInDb == null)
            {
                return HttpNotFound();
            }

            var model = new RegisterViewModel
            {
                Username = userInDb.UserName,
                Firstname = userInDb.Firstname,
                Middlename = userInDb.Middlename,
                Lastname = userInDb.Lastname,
                Email = userInDb.Email,
                PhoneNumber = userInDb.PhoneNumber,
            };
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, RegisterViewModel model)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userInDb = db.Users.FirstOrDefault(u => u.UserName == id);
            if (userInDb == null)
            {
                return HttpNotFound();
            }

            userInDb.UserName = model.Username;
            userInDb.Firstname = model.Firstname;
            userInDb.Middlename = model.Middlename;
            userInDb.Lastname = model.Lastname;
            userInDb.Email = model.Email;
            userInDb.PhoneNumber = model.PhoneNumber;

            db.Entry(userInDb).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userInDb = db.Users.FirstOrDefault(u => u.UserName == id);
            if (userInDb == null)
            {
                return HttpNotFound();
            }
            return View(userInDb);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var userInDb = db.Users.FirstOrDefault(u => u.UserName == id);
            db.Users.Remove(userInDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
