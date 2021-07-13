using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD_Operations.Data;
using MVC_CRUD_Operations.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD_Operations.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Create from page view action
        public IActionResult Create()
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        //Post Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.Category.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            
            return View();
        }

        //Post Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Userpswd obj)
        {
            if (obj.username == "vanki" && obj.pswd == "123") {
                //var student = JsonConvert.DeserializeObject<Student>(HttpContext.Session.GetString("studentSession"));
                HttpContext.Session.SetString("username", JsonConvert.SerializeObject("vanki"));
                return RedirectToAction("Index");
               
            }

            return View();
        }


        //Get Request
        public IActionResult Index()
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null)
            {
                return RedirectToAction("Login");
            }
            IEnumerable<Category> objlist = _db.Category;
            var username=JsonConvert.DeserializeObject<String>(HttpContext.Session.GetString("username"));

            return View(objlist);
        }

        


        //GET - EDIT
        public IActionResult Edit(int? id)
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null) {
                return RedirectToAction("Login");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            var sessionvalue = HttpContext.Session.GetString("username");
            if (sessionvalue == null)
            {
                return RedirectToAction("Login");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        public IActionResult SessionEnd()
        {

            foreach (var cookie in Request.Cookies.Keys)

            {
                if (cookie == ".AspNetCore.Session")
                    Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Login");
        }


    }
}
