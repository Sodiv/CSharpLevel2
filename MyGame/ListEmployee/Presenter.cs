using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListEmployee
{
    public class Presenter
    {
        Model model;

        public Presenter()
        {
            model = new Model();
            
        }
        /// <summary>
        /// Data Context
        /// </summary>
        /// <returns>Возврат таблицы данных</returns>
        public object Data()
        {
            return model.dataTable.DefaultView;
        }

        public void Dep()
        {
            DepartmentWindow departmentWindow = new DepartmentWindow(this);
            departmentWindow.Show();
        }

        public object DataDep()
        {
            return model.dtDep.DefaultView;
        }
        /// <summary>
        /// Удаление данных
        /// </summary>
        /// <param name="dataRow">Удаляемая строка</param>
        public void Delete(DataRowView dataRow)
        {
            DataRowView newRow = dataRow;
            newRow.Row.Delete();
            model.adapter.Update(model.dataTable);
        }
        /// <summary>
        /// Обновление данных
        /// </summary>
        /// <param name="dataRow">Обновляемая строка</param>
        public void Update(DataRowView dataRow)
        {
            if (dataRow == null) return;
            DataRowView newRow = dataRow;
            newRow.BeginEdit();

            EditEmployeeWindow editWindow = new EditEmployeeWindow(newRow.Row);
            editWindow.ShowDialog();
            if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
            {
                newRow.EndEdit();
                model.adapter.Update(model.dataTable);
            }
            else
            {
                newRow.CancelEdit();
            }
        }
        /// <summary>
        /// Добавление данных
        /// </summary>
        public void Add()
        {
            DataRow newRow = model.dataTable.NewRow();
            EditEmployeeWindow editEmployeeWindow = new EditEmployeeWindow(newRow);
            editEmployeeWindow.ShowDialog();

            if (editEmployeeWindow.DialogResult.Value)
            {
                model.dataTable.Rows.Add(editEmployeeWindow.resultRow);
                model.adapter.Update(model.dataTable);
            }
        }

        public void DeleteDep(DataRowView dataRow)
        {
            DataRowView newRow = dataRow;
            newRow.Row.Delete();
            model.adapterDep.Update(model.dtDep);            
        }
    }
}
