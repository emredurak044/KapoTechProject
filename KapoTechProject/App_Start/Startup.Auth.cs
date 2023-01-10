﻿using KapoTechProject.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(KapoTechProject.App_Start.Startup))]

namespace KapoTechProject.App_Start
{
    public class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Veritabanı bağlamını ve kullanıcı yöneticisini ve oturum açma yöneticisini istek başına tek örnek kullanacak şekilde yapılandırın
            app.CreatePerOwinContext(KapoTechContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Oturum açmış kullanıcı hakkında bilgi toplamak için uygulamada çerez kullanımını etkinleştirin
            // ve üçüncü taraf bir oturum açma sağlayıcısı üzerinden oturum açan kullanıcı bilgilerini tanımlama bilgileri olarak saklamak için tanımlama bilgisi kullanmasını sağlayın
            // Oturum açma tanımlama bilgilerini yapılandırın
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login/SignIn"),
                Provider = new CookieAuthenticationProvider
                {
                    // Kullanıcı oturum açtığında güvenlik damgasının uygulama tarafından doğrulanmasını sağlar.
                    // Bu, parola değiştirdiğinizde veya hesabınıza dış oturum eklediğinizde kullanılan bir güvenlik özelliğidir.
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // İki öğeli kimlik doğrulama işleminde ikinci öğeyi doğrulama sırasında uygulamanın, kullanıcı bilgilerini geçici olarak saklanmasını sağlar.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Uygulamanın, telefon veya e-posta gibi ikinci oturum açma doğrulama öğesini hatırlamasını sağlar.
            // Bu seçeneği işaretlerseniz, oturum açma işlemi sırasındaki ikinci doğrulama adımınız oturum açtığınız cihazda hatırlanır.
            // Bu, oturum açarken kullandığınız Beni Hatırla seçeneğine benzer.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Üçüncü taraf oturum sağlayıcılarla oturum açmaya olanak tanımak için aşağıdaki satırlardan açıklamayı kaldırın
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}