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
        private string url = @"http://localhost:52137/";
        HttpClient httpClient;
        public Model()
        {
            Employees = new ObservableCollection<Employee>();
            httpClient = new HttpClient();
        }

        public void Load()
        {
            var res = httpClient.GetStringAsync($"{url}getemployee").Result;
            var json = JsonConvert.DeserializeObject<Employee[]>(res);
            foreach(var employee in json)
            {
                Employees.Add(employee);
            }
        }
    }
}
