using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RSOE.Models;
using RSOE.Models.ViewModels;
using RSOE.Repository.Interfaces;
using System.Collections.Generic;

namespace RSOE.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository<Employee> employeeRepo;
        private readonly IRepository<Company> companyRepo;
        private readonly IRepository<Position> positionRepo;

        public EmployeeController(IRepository<Employee> employeeRepo, IRepository<Company> companyRepo, IRepository<Position> positionRepo)
        {
            this.employeeRepo = employeeRepo;
            this.companyRepo = companyRepo;
            this.positionRepo = positionRepo;
        }

        public ActionResult Index()
        {
            var employees = employeeRepo.GetAll();
            var employeesListViewModel = new List<EmployeePageViewModel>();

            foreach(var employee in employees)
            {
                var employeeViewModel = new EmployeePageViewModel();

                employeeViewModel.EmployeeId = employee.EmployeeId;
                employeeViewModel.EmploymentDate = employee.EmploymentDate;
                employeeViewModel.FirstName = employee.FirstName;
                employeeViewModel.LastName = employee.LastName;
                employeeViewModel.Company = companyRepo.GetById(employee.CompanyId).Name;
                employeeViewModel.Position = positionRepo.GetById(employee.PositionId).Name;

                employeesListViewModel.Add(employeeViewModel);
            }

            return View(employeesListViewModel);
        }

        public ActionResult Create()
        {
            SelectList companies = new SelectList(companyRepo.GetAll(), "CompanyId", "Name");
            SelectList positions = new SelectList(positionRepo.GetAll(), "PositionId", "Name");

            ViewBag.Companies = companies;
            ViewBag.Positions = positions;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepo.Create(employee);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employee = employeeRepo.GetById(id);

            SelectList companies = new SelectList(companyRepo.GetAll(), "CompanyId", "Name");
            SelectList positions = new SelectList(positionRepo.GetAll(), "PositionId", "Name");

            ViewBag.Companies = companies;
            ViewBag.Positions = positions;

            if (employee == null)
            {
                return new StatusCodeResult(404);
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            employeeRepo.Update(employee);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var employee = employeeRepo.GetById(id);

            if (employee == null)
            {
                return new StatusCodeResult(404);
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var employee = employeeRepo.GetById(id);

            employeeRepo.Delete(employee);

            return RedirectToAction("Index");
        }
    }
}
