using JobsForYou.Data;
using JobsForYou.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobsForYou.WebMVC.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            //refactor?? var service = CreateJobService();
            var model = service.GetJobs();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateJobService();

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "Your Job was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Job Could Not be created");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateJobService();
            var detail = service.GetJobById(id);
            var model =
                new JobEdit
                {
                    JobId = detail.JobId,
                    ProviderId=detail.ProviderId,
                    CustomerId = detail.CustomerId,
                    Description = detail.Description,
                    Location = detail.Location,
                    JobType = detail.JobType,
                    ModifiedUtc = DateTimeOffset.Now,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.JobId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }
            var service = CreateJobService();

            if (service.UpdateJob(model))
            {
                TempData["SaveResult"] = "your Job Was Updated";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Youre job could not be updated");
            return View();
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobService();
            service.DeleteJob(id);

            TempData["SaveResult"] = "You're job was deleted";

            return RedirectToAction("Index");
        }


        private JobService CreateJobService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JobService(userId);
            return service;
        }
    }
}