using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ListEmployee
{
    /// <summary>
    /// Модель адаптера обращения к БД
    /// </summary>
    public class Model
    {
        string conString;
        public SqlDataAdapter adapter;
        public DataTable dataTable { get; set; }
        public SqlDataAdapter adapterDep;
        public DataTable dtDep { get; set; }
        public Model()
        {
            conString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(conString);
            adapter = new SqlDataAdapter();
            adapterDep = new SqlDataAdapter();
            #region Заполнение первичными данными
            //Random rnd = new Random();                                 
            //sqlConnection.Open();
            //for (int i = 0; i < 5; i++)
            //{
            //    var sqld = $@"INSERT INTO Department(Name) VALUES ('dep_{i}')";
            //    //sqlConnection.Open();
            //    SqlCommand command = new SqlCommand(sqld, sqlConnection);
            //    command.ExecuteNonQuery();
            //    //sqlConnection.Close();
            //}
            //for (int i = 0; i < 15; i++)
            //{
            //    var sqle = $@"INSERT INTO Employee(Name, Age, DepartmentId) VALUES ('name_{i}', {20 + i / 2 }, {rnd.Next(0, 5)})";
            //    //sqlConnection.Open();
            //    SqlCommand command = new SqlCommand(sqle, sqlConnection);
            //    command.ExecuteNonQuery();
            //    //sqlConnection.Close();
            //}
            //sqlConnection.Close();
            #endregion
            #region Работа  Employee
            SqlCommand command = new SqlCommand(@"SELECT Employee.Id, Employee.Name, Employee.Age, Department.Name AS Department FROM 
Employee LEFT JOIN Department ON Employee.DepartmentId=Department.Id", sqlConnection);
            adapter.SelectCommand = command;

            command = new SqlCommand(@"INSERT INTO Employee(Name, Age, DepartmentId) VALUES (@Name, @Age, (SELECT ID FROM Department WHERE Name LIKE @Department)); SET @ID=@@IDENTITY;", sqlConnection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            command.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, 50, "Department");
            SqlParameter param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = command;

            command = new SqlCommand(@"UPDATE Employee SET Name=@Name, Age=@Age, DepartmentId=(SELECT ID FROM Department WHERE Name LIKE @Department) WHERE Id=@Id", sqlConnection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            command.Parameters.Add("@Age", SqlDbType.Int, 0, "Age");
            command.Parameters.Add("@Department", SqlDbType.NVarChar, 50, "Department");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

            param.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = command;

            command = new SqlCommand(@"DELETE FROM Employee WHERE Id=@Id", sqlConnection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = command;
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            #endregion
            command = new SqlCommand(@"Select * from Department", sqlConnection);
            adapterDep.SelectCommand = command;

            command = new SqlCommand(@"Insert into Department(Name) VALUES (@Name); Set @Id=@@IDENTITY;", sqlConnection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            adapter.InsertCommand = command;

            command = new SqlCommand(@"UPDATE Department SET Name=@Name WHERE Id=@Id", sqlConnection);
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            adapterDep.UpdateCommand = command;

            command = new SqlCommand(@"DELETE FROM Employee WHERE DepartmentId=@Id; DELETE FROM Department WHERE Id=@Id;", sqlConnection);
            param = command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            param.SourceVersion = DataRowVersion.Original;
            adapterDep.DeleteCommand = command;
            dtDep = new DataTable();
            adapterDep.Fill(dtDep);
        }
    }
}
