using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_ToDoLab.Models
{
    public class ToDoDAL
    {
        string connection = Secret.Connection;

        public List<Employee> GetEmployees()
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = "select * from employees";
                connect.Open();
                List<Employee> employees = connect.Query<Employee>(sql).ToList();
                connect.Close();
                return employees;
            }
        }

        public Employee GetEmployee(int id)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"select * from employees " +
                    $"where Employee_Id = {id}";
                connect.Open();
                Employee employee = connect.Query<Employee>(sql).First();
                connect.Close();
                return employee;
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"insert into employees " +
                    $"values({0}, '{employee.FullName}', {employee.Hours}, '{employee.Title}')";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void EditEmployee(Employee employee)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"update employees " +
                    $"set FullName = '{employee.FullName}', Hours = {employee.Hours}, Title = '{employee.Title}' " +
                    $"where Employee_Id = {employee.Employee_Id}";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void AddEmployeeHours(Employee employee)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"update employees " +
                    $"set hours = {employee.Hours} " +
                    $"where employee_id = {employee.Employee_Id}";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public void RemoveEmployee(int id)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"delete from employees " +
                    $"where employee_id = {id}";
                connect.Open();
                connect.Query<Employee>(sql);
                connect.Close();
            }
        }

        public List<ToDo> GetToDos()
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = "select * from to_dos";
                connect.Open();
                List<ToDo> ToDos = connect.Query<ToDo>(sql).ToList();
                connect.Close();
                return ToDos;
            }
        }

        public ToDo GetToDo(int id)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"select * from to_dos " +
                    $"where todo_id = {id}";
                connect.Open();
                ToDo toDo = connect.Query<ToDo>(sql).First();
                connect.Close();
                toDo.Employee = GetEmployees();
                return toDo;
            }
        }

        public void AssignToDo(ToDo toDo)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql;
                if (toDo.Assigned_To == 0)
                {
                    sql = $"update to_dos " +
                    $"set assigned_to = null " +
                    $"where todo_id = {toDo.Todo_Id}";
                }
                else
                {
                    sql = $"update to_dos " +
                    $"set assigned_to = {toDo.Assigned_To} " +
                    $"where todo_id = {toDo.Todo_Id}";
                }
                
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }
        
        public void EditComplete(ToDo toDo)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"update to_dos " +
                    $"set is_completed = {toDo.Is_Completed} " +
                    $"where todo_id = {toDo.Todo_Id}";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

        public void AddToDo(ToDo toDo)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql;
                if (toDo.Assigned_To == 0)
                {
                    sql = $"insert into to_dos " +
                    $"values({0}, '{toDo.Task_Name}', '{toDo.Task_Description}', null, {toDo.Hours_Needed}, {false})";
                }
                else
                {
                    sql = $"insert into to_dos " +
                    $"values({0}, '{toDo.Task_Name}', '{toDo.Task_Description}', {toDo.Assigned_To}, {toDo.Hours_Needed}, {false})";
                }
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }

        public void RemoveToDo(int id)
        {
            using (var connect = new MySqlConnection(connection))
            {
                string sql = $"delete from to_dos " +
                    $"where todo_id = {id}";
                connect.Open();
                connect.Query<ToDo>(sql);
                connect.Close();
            }
        }
    }
}
