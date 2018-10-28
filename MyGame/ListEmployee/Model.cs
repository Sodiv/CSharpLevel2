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
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; }
        }
        private string url = @"http://localhost:52137/";
        HttpClient httpClient;
        public Model()
        {
            Employees = new ObservableCollection<Employee>();
            httpClient = new HttpClient();
        }

        public void Load()
        {
            var json = JsonConvert.DeserializeObject<Employee[]>(httpClient.GetStringAsync($"{url}getemployee").Result);
            foreach(var employee in json)
            {
                Employees.Add(employee);
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
    }
}
