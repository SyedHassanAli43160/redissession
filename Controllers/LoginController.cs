using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using redissession.Models;
namespace redissession.Controllers
{
    public class LoginController : Controller
    {
      
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginController/Details/5
        public ActionResult Details()
        {
            ViewBag.data = HttpContext.Session.GetString("key");
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {          
        
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        
        public IActionResult Create(Login user)
        {
          
                var email = user.email;
                if (email != null)
                {
                    HttpContext.Session.SetString("key", email);
            
                return RedirectToAction("Details");
                }
            else
            {
                return View();
            }
          
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
