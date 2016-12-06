using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Models;
using SmartStorage.UI.ViewModels.Identity;

namespace SmartStorage.UI.Controllers
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
        FullName = userInDb.FullName,
        Email = userInDb.Email,
        PhoneNumber = userInDb.PhoneNumber,
        ProfilePicture = userInDb.ProfilePicture
      }).ToList();
      if (User.IsInRole(UserRolesName.Admin))
        return View("Index", usersInDb);
      return View("ReadOnlyIndex", usersInDb);
    }

    // GET: User/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: User/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(UserViewModel model)
    {

      if (ModelState.IsValid)
      {


        var user = new ApplicationUser
        {
          UserName = model.Email,
          Email = model.Email,
          PhoneNumber = model.PhoneNumber,
          FullName = model.FullName,
          ProfilePicture = model.ProfilePicture
        };
        var result = await UserManager.CreateAsync(user, "SmartStorage.2016");
        if (result.Succeeded)
        {
          if (model.IsAdmin)
          {
            await UserManager.AddToRoleAsync(user.Id, "Admin");
          }
          else
          {
            await UserManager.RemoveFromRoleAsync(user.Id, "Admin");
          }

          user.LockoutEnabled = true;
          string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
          var callbackUrl = Url.Action("ActivateAccount", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
          await UserManager.SendEmailAsync(user.Id, "Activate Account", "Please activate your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

          //await
          //UserManager.SendSmsAsync(user.Id,
          //  "Welcome to SmartStorage.dk, we have sendt your a activaction link on: " + user.Email + ", enjoy :)");

          return RedirectToAction("Index");
        }
        AddErrors(result);
      }

      return View(model);
    }

    // GET: User/Edit/5
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var userInDb = db.Users.SingleOrDefault(u => u.PhoneNumber == id);
      if (userInDb == null)
      {
        return HttpNotFound();
      }

      var model = new RegisterViewModel
      {
        Username = userInDb.UserName,
        FullName = userInDb.FullName,
        Email = userInDb.Email,
        PhoneNumber = userInDb.PhoneNumber
      };
      model.IsAdmin = UserManager.IsInRole(userInDb.Id, "Admin");
      return View(model);
    }

    // POST: User/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public async Task<ActionResult> Edit(string id, RegisterViewModel model)
    {

      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var userInDb = db.Users.FirstOrDefault(u => u.PhoneNumber == id);
      if (userInDb == null)
      {
        return HttpNotFound();
      }

      userInDb.UserName = model.Username;
      userInDb.FullName = model.FullName;
      userInDb.Email = model.Email;
      userInDb.PhoneNumber = model.PhoneNumber;

      db.Entry(userInDb).State = EntityState.Modified;

      db.SaveChanges();

      if (model.IsAdmin)
      {
        await UserManager.AddToRoleAsync(userInDb.Id, "Admin");
      }
      else
      {
        await UserManager.RemoveFromRoleAsync(userInDb.Id, "Admin");
        if (userInDb.UserName == User.Identity.Name)
        {
          HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
          return RedirectToAction("Index", "Home");
        }
      }

      return RedirectToAction("Index");
    }

    // GET: User/Delete/5
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Delete(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var userInDb = db.Users.FirstOrDefault(u => u.PhoneNumber == id);
      if (userInDb == null)
      {
        return HttpNotFound();
      }
      return View(userInDb);
    }

    // POST: User/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult DeleteConfirmed(string id)
    {
      var userInDb = db.Users.FirstOrDefault(u => u.PhoneNumber == id);
      if (userInDb == null)
      {
        return View("Index");
      }
      if (userInDb.UserName == User.Identity.Name)
      {
        db.Users.Remove(userInDb);
        db.SaveChanges();
        HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        return RedirectToAction("Index", "Home");
      }

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
