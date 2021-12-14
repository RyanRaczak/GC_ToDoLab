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
                string sql = $"insert into employees " +
                    $"set FullName = '{employee.FullName}', Hours = {employee.Hours}, Title = '{employee.Title}' " +
                    $"where Employee_Id = {employee.Employee_Id}";
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

        
    }
}
