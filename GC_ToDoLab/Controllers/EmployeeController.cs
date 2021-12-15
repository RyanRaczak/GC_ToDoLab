using GC_ToDoLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_ToDoLab.Controllers
{
    public class EmployeeController : Controller
    {
        ToDoDAL db = new ToDoDAL();
        public IActionResult Index()
        {
            List<Employee> employees = db.GetEmployees();
            return View(employees);
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            db.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult EditEmployee(int id)
        {
            Employee employee = db.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {
            db.EditEmployee(employee);
            return RedirectToAction("Index");
        }
        
        public IActionResult DeleteEmployee(int id)
        {
            Employee emp = db.GetEmployee(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult DeleteEmployeeFromDB(int id)
        {
            db.RemoveEmployee(id);
            return RedirectToAction("Index");
        }

    }
}
