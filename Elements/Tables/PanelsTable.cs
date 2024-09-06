using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Octopus.Tables.Elements
{
    class PanelsTable : Panel
    {
        static readonly string[] headerNames = new string[] { "Ключ", "Значение" };
        const int TableWidth = 1360;

        public static PanelsTable CreateTable(Dictionary<string, string> dataSource)
        {
            TextBox headerKeyText = new TextBox();
            headerKeyText.Dock = DockStyle.Left;
            headerKeyText.Size = new System.Drawing.Size(TableWidth/2, 30);
            headerKeyText.ReadOnly = true;
            headerKeyText.Text = headerNames[0];
            headerKeyText.BackColor = Color.Wheat;
            headerKeyText.ForeColor = Color.Black;
            headerKeyText.Multiline = true;

            TextBox headerValueText = new TextBox();
            headerValueText.Dock = DockStyle.Right;
            headerValueText.Size = new System.Drawing.Size(TableWidth / 2, 30);
            headerValueText.ReadOnly = true;
            headerValueText.Text = headerNames[1];
            headerValueText.BackColor = Color.Wheat;
            headerValueText.ForeColor = Color.Black;
            headerValueText.Multiline = true;

            Panel header = new Panel();
            header.Dock = DockStyle.Top;
            header.Size = new System.Drawing.Size(TableWidth, 30);
            header.Controls.Add(headerValueText);
            header.Controls.Add(headerKeyText);

            FlowLayoutPanel dataPanel = new FlowLayoutPanel();
            dataPanel.Dock = DockStyle.Fill;
            dataPanel.Width = TableWidth;
            foreach(var data in dataSource)
            {
                TextBox cellKey = new TextBox();
                cellKey.Dock = DockStyle.Left;
                cellKey.Width = TableWidth / 2;
                cellKey.ReadOnly = true;
                cellKey.Multiline = true;
                cellKey.Text = data.Key;
                //cellKey.Size = new System.Drawing.Size(TableWidth / 2, 30);
                cellKey.Width = headerKeyText.Width;

                TextBox cellValue = new TextBox();
                cellValue.Dock = DockStyle.Right;
                cellValue.Width = TableWidth / 2;
                cellValue.ReadOnly = true;
                cellValue.Multiline = true;
                cellValue.Text = data.Value;
                cellValue.Width = headerValueText.Width;
                //cellValue.Size = new System.Drawing.Size(TableWidth / 2, 30);

                Panel row = new Panel();
                row.Dock = DockStyle.Top;
                row.Width = TableWidth;
                row.Controls.Add(cellKey);
                row.Controls.Add(cellValue);
                if(cellKey.Height > cellValue.Height)
                    row.Size = new System.Drawing.Size(TableWidth, cellKey.Height);
                else
                    row.Size = new System.Drawing.Size(TableWidth, cellValue.Height);
                row.BackColor  = Color.Red;

                dataPanel.Controls.Add(row);
            }

            PanelsTable table = new PanelsTable();
            table.Dock = DockStyle.Fill;
            table.Size = new System.Drawing.Size(1360, 324);
            table.Controls.Add(dataPanel);
            table.Controls.Add(header);

            return table;
        }
    }
}
