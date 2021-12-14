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


    }
}
