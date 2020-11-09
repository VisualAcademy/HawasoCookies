using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hawaso.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            if (email == "a@a.com" && password == "password")
            {
                // DotNetNoteCookies 
                //[!] 인증 부여: 인증된 사용자의 주요 정보(Name, Role, ...)를 기록
                var claims = new List<Claim>
                {
                    // 로그인 아이디 지정
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, "박용준"), 

                    //[!] 새로운 Claim 개체 추가 가능
                    // https://docs.microsoft.com/en-us/windows-server/identity/ad-fs/technical-reference/the-role-of-claims
                    new Claim("Job", "Programmer"),

                };

                var ci = new ClaimsIdentity(claims, 
                    CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme
                    , new ClaimsPrincipal(ci));

                return LocalRedirect(Url.Content("~/")); 
            }

            return View();
        }

        [Authorize]
        public IActionResult UserInfor() => View(); 
    }
}
