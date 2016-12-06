using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Sms.ApiClient.V2;
using Sms.ApiClient.V2.SendMessages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace I4PRJ_SmartStorage
{
  public class EmailService : IIdentityMessageService
  {
    public async Task SendAsync(IdentityMessage message)
    {
      await SendViaSmtp(message);
    }

    private async Task SendViaSmtp(IdentityMessage message)
    {
      var emailMessage = new MailMessage();
      emailMessage.To.Add(new MailAddress(message.Destination));
      emailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SmtpFrom"]);
      emailMessage.Subject = message.Subject;
      emailMessage.Body = message.Body;
      emailMessage.IsBodyHtml = true;

      using (var smtpClient = new SmtpClient())
      {
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpUserName"],
        ConfigurationManager.AppSettings["SmtpPassword"]);
        smtpClient.Host = ConfigurationManager.AppSettings["SmtpHost"];
        smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
        smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SmtpEnableSsl"]);

        await smtpClient.SendMailAsync(emailMessage);
      }
    }
  }

  public class SmsService : IIdentityMessageService
  {
    public async Task SendAsync(IdentityMessage message)
    {
      await SendViaInMobile(message);
    }

    private Task SendViaInMobile(IdentityMessage message)
    {
      var smsClient = new FacadeSmsClient(
            hostRootUrl: ConfigurationManager.AppSettings["SmsHost"],
            apiKey: ConfigurationManager.AppSettings["SmsApi"]);

      var smsMessagesToSend = new List<ISmsMessage>();
      var smsMessage = new SmsMessage(
                  msisdn: "45" + message.Destination,
                  text: message.Body,
                  senderName: ConfigurationManager.AppSettings["SmsFrom"],
                  encoding: SmsEncoding.Gsm7);
      smsMessagesToSend.Add(smsMessage);

      smsClient.SendMessages(
                        messages: smsMessagesToSend,
                        messageStatusCallbackUrl: "https://smartstorage.dk/api/sms/callback");

      return Task.CompletedTask;
    }
  }

  // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
  public class ApplicationUserManager : UserManager<ApplicationUser>
  {
    public ApplicationUserManager(IUserStore<ApplicationUser> store)
        : base(store)
    {
    }

    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
        IOwinContext context)
    {
      var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
      // Configure validation logic for usernames
      manager.UserValidator = new UserValidator<ApplicationUser>(manager)
      {
        AllowOnlyAlphanumericUserNames = false,
        RequireUniqueEmail = true
      };

      // Configure validation logic for passwords
      manager.PasswordValidator = new PasswordValidator
      {
        RequiredLength = 6,
        RequireNonLetterOrDigit = false,
        RequireDigit = false,
        RequireLowercase = false,
        RequireUppercase = false,
      };

      // Configure user lockout defaults
      manager.UserLockoutEnabledByDefault = true;
      manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
      manager.MaxFailedAccessAttemptsBeforeLockout = 5;

      // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
      // You can write your own provider and plug it in here.
      manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
      {
        MessageFormat = "Your security code is {0}"
      });
      manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
      {
        Subject = "Security Code",
        BodyFormat = "Your security code is {0}"
      });
      manager.EmailService = new EmailService();
      manager.SmsService = new SmsService();
      var dataProtectionProvider = options.DataProtectionProvider;
      if (dataProtectionProvider != null)
      {
        manager.UserTokenProvider =
            new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
            {
              TokenLifespan = TimeSpan.FromMinutes(15)
            };
      }
      return manager;
    }
  }

  // Configure the application sign-in manager which is used in this application.
  public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
  {
    public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
        : base(userManager, authenticationManager)
    {
    }

    public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
    {
      return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
    }

    public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options,
        IOwinContext context)
    {
      return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
    }
  }
}