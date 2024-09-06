using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octopus.Elements.Tables
{
    class DGVTable : DataGridView
    {
        const int TableWidth = 1200;

        public static DGVTable CreateTable(Dictionary<string, string> dataSource)
        {
            DGVTable table = new DGVTable();
            table.Dock = DockStyle.Fill;
            table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            table.AllowUserToAddRows = false;
            table.AllowUserToDeleteRows = false;
            table.AllowUserToResizeRows = false;

            DataGridViewColumn columnKey = new DataGridViewColumn();
            columnKey.CellTemplate = new DataGridViewTextBoxCell();
            columnKey.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            columnKey.HeaderText = "Ключ";
            table.Columns.Add(columnKey);

            DataGridViewColumn columnValue = new DataGridViewColumn();
            columnValue.CellTemplate = new DataGridViewTextBoxCell();
            columnValue.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            columnValue.HeaderText = "Значение";
            table.Columns.Add(columnValue);

            foreach(var data in dataSource)
                table.Rows.Add(new string[] {data.Key, data.Value});
            return table;
        }
    }
}
