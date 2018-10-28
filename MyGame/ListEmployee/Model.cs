using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace ListEmployee
{
    /// <summary>
    /// Модель адаптера обращения к БД
    /// </summary>
    public class Model
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        private Employee selectedEmployee;
        private Department selectedDepartment;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; }
        }
        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set { selectedDepartment = value; }
        }
        private string url = @"http://localhost:52137/";
        HttpClient httpClient;
        public Model()
        {
            Employees = new ObservableCollection<Employee>();
            Departments = new ObservableCollection<Department>();
            httpClient = new HttpClient();
        }

        public void Load()
        {
            var json = JsonConvert.DeserializeObject<Employee[]>(httpClient.GetStringAsync($"{url}getemployee").Result);
            var jsond = JsonConvert.DeserializeObject<Department[]>(httpClient.GetStringAsync($"{url}getdepartment").Result);
            foreach (var employee in json)
            {
                Employees.Add(employee);
            }            
            foreach(var department in jsond)
            {
                Departments.Add(department);
            }
        }

        public void Add(Employee value)
        {
            string obj = @"{'Name': '" + value.Name + "', " +
                "'Age': '" + value.Age + "', " +
                "'Department': '" + value.Department + "'}";
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            httpClient.PostAsync($"{url}addemployee", content);
            Employees.Clear();
            Load();
        }

        public void Edit(Employee value)
        {            
            string obj = @"{'Name': '" + value.Name + "', " +
                "'Age': '" + value.Age + "', " +
                "'Department': '" + value.Department + "'}";
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            httpClient.PostAsync($"{url}editemployee/{value.Id}", content);            
        }

        public void Delete(int id)
        {
            httpClient.GetAsync($"{url}deleteemployee/{id}");
            Employees.Remove(selectedEmployee);
        }

        public void Add(Department value)
        {
            string obj = @"{'Name': '" + value.Name + "'}";
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            httpClient.PostAsync($"{url}adddepartment", content);
            Departments.Clear();
            Load();
        }

        public void Edit(Department value)
        {
            string obj = @"{'Name': '" + value.Name + "'}";
            StringContent content = new StringContent(obj, Encoding.UTF8, "application/json");
            httpClient.PostAsync($"{url}editdepartment/{value.Id}", content);
            Employees.Clear();
            Departments.Clear();
            Load();
        }

        public void DeleteD(int id)
        {
            httpClient.GetAsync($"{url}deletedepartment/{id}");
            Departments.Remove(selectedDepartment);
            Employees.Clear();
            Departments.Clear();
            Load();
        }
    }
}
