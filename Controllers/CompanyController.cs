using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RSOE.Models;
using RSOE.Repository;
using RSOE.Repository.Interfaces;

namespace RSOE.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IRepository<Company> companyRepo;

        public CompanyController(IRepository<Company> companyRepo)
        {
            this.companyRepo = companyRepo;
        }

        public ActionResult Index()
        {
            var companies = companyRepo.GetAll();

            return View(companies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                companyRepo.Create(company);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company = companyRepo.GetById(id);

            if (company == null)
            {
                return new StatusCodeResult(404);
            }

            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            companyRepo.Update(company);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var company = companyRepo.GetById(id);

            if (company == null)
            {
                return new StatusCodeResult(404);
            }

            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var company = companyRepo.GetById(id);

            companyRepo.Delete(company);

            return RedirectToAction("Index");
        }
    }
}
