using MVC.UsersClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserClient service;

        public UsersController()
        {
            service = new UserClient();
        }

        // GET: Users
        public ActionResult Index(int page = 0)
        {
            const int PageSize = 3; // you can always do something more elegant to set this

            var list = new List<UserVM>(service.All());
            var count = list.Count;

            var data = list.Skip(page * PageSize).Take(PageSize).ToList();

            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            ViewBag.Page = page;

            ViewBag.PageSize = (count + PageSize - 1) / PageSize;


            return View(data);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new SelectList(new List<Object> { new { Id = 1, Value = "Masculino" }, new { Id = 2, Value = "Femenino" } }, "Id", "Value");

            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UserVM model)
        {
            try
            {
                if (ModelState.IsValid && service.Insert(model))
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            var item = service.Show(id);

            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender = new SelectList(new List<Object> { new { Id = 1, Value = "Masculino" }, new { Id = 2, Value = "Femenino" } }, "Id", "Value", item.Gender);
            return View(item);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (service.Update(id, model))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return View(model);
        }

        // POST: Users/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var status = false;
            var message = "Registro Eliminado Correctamente";
            try
            {
                var item = service.Show(id);

                if (item == null)
                {
                    message = "Registro no Existe";
                }
                else
                {
                    service.Delete(id);
                    status = true;
                }

            }
            catch (Exception ex)
            {
                message = $"Error {ex.Message}";
            }

            return new JsonResult
            {
                Data = new
                {
                    status,
                    message
                }
            };
        }
    }
}
