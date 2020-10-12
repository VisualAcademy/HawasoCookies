using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hawaso.Controllers
{
    public class LogoutController : Controller
    {
        //public async Task<IActionResult> Index()
        //{
        //    // 로그아웃
        //    await HttpContext.SignOutAsync(
        //        CookieAuthenticationDefaults.AuthenticationScheme);

        //    return LocalRedirect("/");
        //}
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            // 로그아웃
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return LocalRedirect("/");
        }
    }
}
