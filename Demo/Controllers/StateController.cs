using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("name", name);
            return Content("Data Session Save Success");
        }

        public IActionResult GetSession()
        {
            var data = HttpContext.Session.GetString("name");
            return Content($"Data Session Save Success {data}");
        }

        public IActionResult SetCookie()
        {
            //Session Cookie => lives untill session is alife
            HttpContext.Response.Cookies.Append("name", "test");

            //Presisitent cookie => lives with it's configs
            HttpContext.Response.Cookies.Append("age", "22", new CookieOptions { Expires = DateTime.Now.AddDays(1) });

            return Content("Data Cookie Save Success");
        }

        public IActionResult getCookie()
        {
            var name = HttpContext.Request.Cookies["name"];
            var age = HttpContext.Request.Cookies["age"];
            return Content($"Data Session Save Success {name} | {age}");
        }
    }
}
