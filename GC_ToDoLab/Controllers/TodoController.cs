using GC_ToDoLab.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_ToDoLab.Controllers
{
    public class TodoController : Controller
    {
        ToDoDAL db = new ToDoDAL();
        public IActionResult Index()
        {
            List<ToDo> todos = db.GetToDos();
            return View(todos);
        }

        public IActionResult AssignTask(int id)
        {
            ToDo toDo = db.GetToDo(id);
            return View(toDo);
        }

        [HttpPost]
        public IActionResult AssignTask(ToDo toDo)
        {
            if (toDo.Assigned_To == 0)
            {
                db.AssignToDo(toDo);
            }
            else
            {
                Employee emp = db.GetEmployee(toDo.Assigned_To);
                emp.Hours += toDo.Hours_Needed;
                if (emp.Hours <= 40)
                {
                    db.AddEmployeeHours(emp);
                    db.AssignToDo(toDo);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult EditComplete(int id)
        {
            ToDo toDo = db.GetToDo(id);
            return View(toDo);
        }

        [HttpPost]
        public IActionResult EditComplete(ToDo toDo)
        {
            db.EditComplete(toDo);
            return RedirectToAction("Index");
        }

        public IActionResult CreateTask()
        {
            ToDo toDo = new ToDo();
            toDo.Employee = db.GetEmployees();
            return View(toDo);
        }

        [HttpPost]
        public IActionResult CreateTask(ToDo toDo)
        {
            if (toDo.Assigned_To == 0)
            {
                db.AddToDo(toDo);
            }
            else
            {
                Employee emp = db.GetEmployee(toDo.Assigned_To);
                emp.Hours += toDo.Hours_Needed;
                if (emp.Hours <= 40)
                {
                    db.AddEmployeeHours(emp);
                    db.AddToDo(toDo);
                }  
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteToDo(int id)
        {
            ToDo toDo = db.GetToDo(id);
            return View(toDo);
        }

        [HttpPost]
        public IActionResult DeleteToDoFromDB(int id)
        {
            db.RemoveToDo(id);
            return RedirectToAction("Index");
        }
    }
}
