using JobsForYou.Models;
using JobsForYou.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsForYou.WebMVC.Controllers
{
    [Authorize]
    public class ProviderController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProviderService(userId);
            var model = service.GetProviders();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProviderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            ProviderService service = CreateProviderService();

            if (service.CreateProvider(model))
            {
                TempData["SaveResult"] = "Your Page was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Page Could Not be created");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateProviderService();
            var model = svc.GetProviderById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateProviderService();
            var detail = service.GetProviderById(id);
            var model =
                new ProviderEdit
                {
                    ProviderId = detail.ProviderId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Location = detail.Location,
                    JobSkills = detail.JobSkills,
                    

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProviderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProviderId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }
            var service = CreateProviderService();

            if (service.UpdateProvider(model))
            {
                TempData["SaveResult"] = "your page Was Updated";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Youre page could not be updated");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProviderService();
            var model = svc.GetProviderById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProviderService();
            service.DeleteCustomer(id);

            TempData["SaveResult"] = "You're page was deleted";

            return RedirectToAction("Index");
        }


        private ProviderService CreateProviderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProviderService(userId);
            return service;
        }
    }
}