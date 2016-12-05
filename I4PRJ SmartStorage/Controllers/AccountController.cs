using Facebook;
using I4PRJ_SmartStorage.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace I4PRJ_SmartStorage.Controllers
{
  [Authorize]
  public class AccountController : Controller
  {
    private ApplicationSignInManager _signInManager;
    private ApplicationUserManager _userManager;

    public AccountController()
    {
    }

    public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
    {
      UserManager = userManager;
      SignInManager = signInManager;
    }

    public ApplicationSignInManager SignInManager
    {
      get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
      private set { _signInManager = value; }
    }

    public ApplicationUserManager UserManager
    {
      get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
      private set { _userManager = value; }
    }

    //
    // GET: /Account/Login
    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
      ViewBag.ReturnUrl = returnUrl;
      return View();
    }

    //
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      // Require the user to have a confirmed email before they can log on.
      var user = await UserManager.FindByNameAsync(model.Email);
      if (user != null)
      {
        if (!await UserManager.IsEmailConfirmedAsync(user.Id))
        {
          ViewBag.errorMessage = "You must have a confirmed email to log on.";
          return View("Error");
        }
      }

      // This doesn't count login failures towards account lockout
      // To enable password failures to trigger account lockout, change to shouldLockout: true
      var result =
          await
              SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                  shouldLockout: false);
      switch (result)
      {
        case SignInStatus.Success:
          return RedirectToLocal(returnUrl);
        case SignInStatus.LockedOut:
          return View("Lockout");
        case SignInStatus.Failure:
        default:
          ModelState.AddModelError("", "Invalid login attempt.");
          return View(model);
      }
    }

    public ActionResult Edit()
    {

      var userInDb = UserManager.FindByName(User.Identity.Name);
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
      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(RegisterViewModel model)
    {

      var db = new ApplicationDbContext();
      var userInDb = db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
      if (userInDb == null)
      {
        return HttpNotFound();
      }

      userInDb.UserName = model.Email;
      userInDb.FullName = model.FullName;
      userInDb.Email = model.Email;
      userInDb.PhoneNumber = model.PhoneNumber;

      db.Entry(userInDb).State = EntityState.Modified;

      db.SaveChanges();


      return RedirectToAction("Index", "Manage");
    }

    //
    // GET: /Account/ForgotPassword
    [AllowAnonymous]
    public ActionResult ForgotPassword()
    {
      return View();
    }

    //
    // POST: /Account/ForgotPassword
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
    {
      if (ModelState.IsValid)
      {
        var user = SignInManager.UserManager.Users.FirstOrDefault(u => u.Email == model.Email);
        //var user = await UserManager.FindByNameAsync(model.Email);

        if (user == null /*|| !(await UserManager.IsEmailConfirmedAsync(user.Id))*/)
        {
          // Don't reveal that the user does not exist or is not confirmed
          return View("ForgotPasswordConfirmation");
        }

        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        // Send an email with this link
        string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
        var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
        return RedirectToAction("ForgotPasswordConfirmation", "Account");
      }

      // If we got this far, something failed, redisplay form
      return View(model);
    }

    //
    // GET: /Account/ForgotPasswordConfirmation
    [AllowAnonymous]
    public ActionResult ForgotPasswordConfirmation()
    {
      return View();
    }

    //
    // GET: /Account/ResetPassword
    [AllowAnonymous]
    public ActionResult ResetPassword(string code)
    {
      return code == null ? View("Error") : View();
    }

    //
    // POST: /Account/ResetPassword
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var user = await UserManager.FindByNameAsync(model.Email);
      if (user == null)
      {
        // Don't reveal that the user does not exist
        return RedirectToAction("ResetPasswordConfirmation", "Account");
      }
      var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
      if (result.Succeeded)
      {
        using (var db = new ApplicationDbContext())
        {
          var userInDb = db.Users.FirstOrDefault(u => u.Id == user.Id);
          userInDb.EmailConfirmed = true;
          db.SaveChanges();
        }
        return RedirectToAction("ResetPasswordConfirmation", "Account");
      }
      AddErrors(result);
      return View();
    }

    //
    // GET: /Account/ResetPasswordConfirmation
    [AllowAnonymous]
    public ActionResult ResetPasswordConfirmation()
    {
      return View();
    }

    //
    // GET: /Account/ResetPassword
    [AllowAnonymous]
    public ActionResult ActivateAccount(string code)
    {
      return code == null ? View("Error") : View();
    }

    //
    // POST: /Account/ResetPassword
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> ActivateAccount(ResetPasswordViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      var user = await UserManager.FindByNameAsync(model.Email);
      if (user == null)
      {
        // Don't reveal that the user does not exist
        return RedirectToAction("Login", "Account");
      }
      var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
      if (result.Succeeded)
      {
        using (var db = new ApplicationDbContext())
        {
          var userInDb = db.Users.FirstOrDefault(u => u.Id == user.Id);
          userInDb.EmailConfirmed = true;
          db.SaveChanges();
        }
        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        return RedirectToAction("VerifyPhoneNumber", "Manage", new { PhoneNumber = user.PhoneNumber });
      }
      AddErrors(result);
      return View();
    }

    [AllowAnonymous]
    public ActionResult Facebook()
    {
      return new ChallengeResult("Facebook", Url.Action("GetFacebook", "Account"));
    }

    [AllowAnonymous]
    public async Task<ActionResult> GetFacebook()
    {
      var logInInfo = await AuthenticationManager.GetExternalLoginInfoAsync();

      var identity = AuthenticationManager.GetExternalIdentity(DefaultAuthenticationTypes.ExternalCookie);
      var token = identity.FindFirstValue("FacebookAccessToken");
      var fb = new FacebookClient(token);
      dynamic fbInfo =
          fb.Get(
              "/me?fields=email,name,picture.width(300).height(300)");
      string fbEmail = fbInfo.email;
      var user = UserManager.FindByName(fbEmail);

      if (user == null)
      {
        return RedirectToAction("Login", "Account");
      }

      using (var db = new ApplicationDbContext())
      {
        var userInDb = db.Users.FirstOrDefault(u => u.Id == user.Id);
        if (userInDb != null)
        {
          userInDb.FullName = fbInfo.name;
          userInDb.Email = fbEmail;
          userInDb.UserName = fbEmail;
          userInDb.ProfilePicture = fbInfo.picture.data.url;
          userInDb.EmailConfirmed = true;
          db.SaveChanges();
          await UserManager.AddLoginAsync(user.Id, logInInfo.Login);
          await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
          if (userInDb.PhoneNumberConfirmed == false)
          {
            return RedirectToAction("VerifyPhoneNumber", "Manage", new { PhoneNumber = userInDb.PhoneNumber });
          }
        }

      }
      return RedirectToAction("Index", "Home");
    }

    //
    // POST: /Account/LogOff
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult LogOff()
    {
      AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
      return RedirectToAction("Index", "Home");
    }


    public ActionResult GetProfilePicture(string userId)
    {
      var db = new ApplicationDbContext();

      var user = db.Users.FirstOrDefault(u => u.UserName == userId);

      return Content(user == null ? "/Content/images/rubber-duck.png" : user.ProfilePicture);
    }

    public ActionResult GetFirstName(string userId)
    {
      var db = new ApplicationDbContext();

      var user = db.Users.FirstOrDefault(u => u.UserName == userId);

      if (user == null)
      {
        return Content("Rubber Duck");
      }

      var name = user.FullName.Split(' ');

      return Content(name[0] ?? "Rubber Duck");
    }

    public ActionResult GetFullName(string userId)
    {
      var db = new ApplicationDbContext();

      var user = db.Users.FirstOrDefault(u => u.UserName == userId);

      if (user == null)
      {
        return Content("Rubber Duck");
      }

      return Content(user.FullName ?? "Rubber Duck");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (_userManager != null)
        {
          _userManager.Dispose();
          _userManager = null;
        }

        if (_signInManager != null)
        {
          _signInManager.Dispose();
          _signInManager = null;
        }
      }

      base.Dispose(disposing);
    }

    #region Helpers

    // Used for XSRF protection when adding external logins
    private const string XsrfKey = "XsrfId";

    private IAuthenticationManager AuthenticationManager
    {
      get { return HttpContext.GetOwinContext().Authentication; }
    }

    private void AddErrors(IdentityResult result)
    {
      foreach (var error in result.Errors)
      {
        ModelState.AddModelError("", error);
      }
    }

    private ActionResult RedirectToLocal(string returnUrl)
    {
      if (Url.IsLocalUrl(returnUrl))
      {
        return Redirect(returnUrl);
      }
      return RedirectToAction("Index", "Home");
    }

    internal class ChallengeResult : HttpUnauthorizedResult
    {
      public ChallengeResult(string provider, string redirectUri)
          : this(provider, redirectUri, null)
      {
      }

      public ChallengeResult(string provider, string redirectUri, string userId)
      {
        LoginProvider = provider;
        RedirectUri = redirectUri;
        UserId = userId;
      }

      public string LoginProvider { get; set; }
      public string RedirectUri { get; set; }
      public string UserId { get; set; }

      public override void ExecuteResult(ControllerContext context)
      {
        var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
        if (UserId != null)
        {
          properties.Dictionary[XsrfKey] = UserId;
        }
        context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
      }
    }

    #endregion
  }
}