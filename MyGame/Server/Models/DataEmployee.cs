using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Server.Models
{
    public class DataEmployee
    {
        private SqlConnection sqlConnection;

        public DataEmployee()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns>Массив сотрудников</returns>
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();            
            #region Заполнение БД
            //string nameD = "";
            //string nameE = "";
            //int age = 0;
            //string sqld;
            //string sqle;

            //for (int i = 0; i < 5; i++)
            //{
            //    nameD = $"dep_{i}";
            //    sqld = $@"INSERT INTO Department(Name) VALUES (N'{nameD}')";
            //    using (SqlCommand com = new SqlCommand(sqld, sqlConnection))
            //    {
            //        com.ExecuteNonQuery();
            //    }
            //    for (int j = 0; j < 10; j++)
            //    {                    
            //        nameE = $"name_{j + i * 3}";
            //        age = 20 + j;
            //        sqle = $@"INSERT INTO Employee(Name, Age, DepartmentId) VALUES (N'{nameE}', {age}, (SELECT Id FROM Department WHERE Name LIKE '{nameD}'))";
            //        using (SqlCommand comm = new SqlCommand(sqle, sqlConnection))
            //        {
            //            comm.ExecuteNonQuery();
            //        }
            //    }
            //}
            #endregion
            string sql = @"SELECT Employee.Id, Employee.Name, Employee.Age, Department.Name AS Department FROM Employee LEFT JOIN Department ON Employee.DepartmentId=Department.Id";
            using(SqlCommand com=new SqlCommand(sql, sqlConnection))
            {
                using(SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(
                            new Employee()
                            {
                                Id = reader["Id"].ToString(),
                                Name = reader["Name"].ToString(),
                                Age = reader["Age"].ToString(),
                                Department = reader["Department"].ToString()
                            });
                    }
                }
            }
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            string sqlAdd = $@"INSERT INTO Employee(Name, Age, DepartmentId) 
VALUES (N'{employee.Name}', {employee.Age}, (SELECT Id FROM Department WHERE Name LIKE N'{employee.Department}'));";

            using (var com = new SqlCommand(sqlAdd, sqlConnection))
            {
                com.ExecuteNonQuery();
            }
        }

        public bool EditEmployee(Employee employee, int id)
        {
            try
            {
                string sql = $@"UPDATE Employee SET Name='{employee.Name}', Age={employee.Age}, DepartmentId=(SELECT ID FROM Department WHERE Name LIKE '{employee.Department}') WHERE Id={id}";

                using(var com=new SqlCommand(sql, sqlConnection))
                {
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void DeleteEmployee(int id)
        {
            string sql = $@"DELETE FROM Employee WHERE Id={id}";
            using (var com = new SqlCommand(sql, sqlConnection))
            {
                com.ExecuteNonQuery();
            }
                      
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            string sql = @"SELECT * FROM Department";
            using(SqlCommand com = new SqlCommand(sql, sqlConnection))
            {
                using(SqlDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        departments.Add(
                            new Department()
                            {
                                Id = reader["Id"].ToString(),
                                Name = reader["Name"].ToString()
                            });
                    }
                }
            }
            return departments;
        }

        public void AddDepartment(Department department)
        {
            string sql = $@"INSERT INTO Department(Name) VALUES (N'{department.Name}')";
            using(var com = new SqlCommand(sql, sqlConnection))
            {
                com.ExecuteNonQuery();
            }
        }

        public bool EditDepartment(Department department, int id)
        {
            try
            {
                string sql = $@"UPDATE Department SET Name='{department.Name}' WHERE Id={id}";
                using(var com = new SqlCommand(sql, sqlConnection))
                {
                    com.ExecuteNonQuery();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void DeleteDepartment(int id)
        {
            string sql = $@"DELETE FROM Employee WHERE DepartmentId={id}; DELETE FROM Department WHERE Id={id};";
            using(var com = new SqlCommand(sql, sqlConnection))
            {
                com.ExecuteNonQuery();
            }
        }
    }
}