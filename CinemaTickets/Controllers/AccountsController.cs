using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    public class AccountsController : Controller
    {
        private readonly CinemaTicketDbContext _context;

        public AccountsController(CinemaTicketDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            UserrViewModel userrViewModel = new UserrViewModel();// Sayfa ilk geldiğinde boş gelsin diye postta dolu geliyor.
            return View(userrViewModel);

        }
        [HttpPost]
        public async Task<IActionResult> SignIn([Bind("Emaill", "Passwordd")] UserrViewModel userrViewModel)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identityy = null;
                bool isAuthenticated = false;
                Userr userrr = await _context.Userrs.Include(k => k.Rolee).FirstOrDefaultAsync(m => m.Emaill == userrViewModel.Emaill && m.Passwordd == userrViewModel.Passwordd);

                if (userrr == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
                    return View();
                }



                identityy = new ClaimsIdentity
                (new[]
                        {
                            new Claim(ClaimTypes.Sid,userrr.UserrId.ToString()),
                            new Claim(ClaimTypes.Email,userrr.Emaill),
                            new Claim(ClaimTypes.Role,userrr.Rolee.RoleeName),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                );



                isAuthenticated = true;

                if (isAuthenticated)
                {
                    var claimss = new ClaimsPrincipal(identityy);
                    var loginn = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimss,

                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddMinutes(60)
                        }

                        );
                    if (userrr.Rolee.RoleeName == "PasifKullanıcı")
                    {
                        return Redirect("~/Accounts/ActivationInformation");
                    }
                    else if (userrr.Rolee.RoleeName == "AktifKullanıcı")
                    {
                        return Redirect("~/Home/Index");
                    }

                    else if (userrr.Rolee.RoleeName == "Admin")
                    {
                        return Redirect("~/Admins/Index");
                    }

                    //else if (userrr.Rolee.RoleeName == "User Passive")    /*loginn olurken user passive ise zaten daha baştan yönlendirme yapıldığı için buna gerek kalmadı*/
                    //{
                    //    return Redirect("~/Account/SignupInformationPage");
                    //}
                    else
                    {
                        return Redirect("~/Home/Index");
                    }



                }
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp([Bind("UserrID", "Emaill", "Passwordd", "PasswordRepeatt", "FullName", "Surname", "MobileNO", "RoleeID")] Userr userr)
        {
            userr.RoleeID = 1;
            Userr x = await _context.Userrs.FirstOrDefaultAsync(a => a.Emaill == userr.Emaill);
            if (x != null)
            {
                ModelState.AddModelError("Hata1", "Bu Epostaya ait kullanıcı zaten var");
            }
            if (ModelState.IsValid) // Modelin durumu başarılı ise kurallara uyuyorsa yani, kaydı yap
            {
                await _context.AddAsync(userr);
                await _context.SaveChangesAsync();
                Helpers.EMailWorks.SendActivationEMail(userr.Emaill);
                return RedirectToAction("ActivationInformation", "Accounts");
            }
            return View(userr);// aynı sayfayı girilen bilgiler ile geri getirir bana 
        }
        public IActionResult SignUp()
        {
            Userr user = new Userr();//ilk sayfa açıldığında user null olduğu için value verdik onlar hata verir.Şuan null user verdik get de null gelsin diye
            return View(user);
        }
        public IActionResult Activation(string kkk)
        {
            string eposta = Helpers.EncryptionWorks.EncrWork(kkk);// şifreyi decode etti
            Userr userr = _context.Userrs.FirstOrDefault(a => a.Emaill == eposta);//database deki eposta burada şifresi çözülmüş epostaya eşitse.
            if (userr != null)
            {
                userr.RoleeID = 2;// class düzeyinde güncelledik
                _context.Userrs.Update(userr);//Db düzeyinde güncelledik
                _context.SaveChanges();
                return View(); // aktivasyonun olduğu sayfayı çeviriyotuz girişe yollarsak, aktivasyon olmadı gibi algılıyormuş.

            }
            return View();
        }
        //[Authorize(Roles = "AktifKullanıcı")]
        public IActionResult ActivationInformation()
        {
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
        public IActionResult TermsandConditions()
        {
            return View();
        }
    }
}
