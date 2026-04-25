using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeNamespace;

namespace EmployeeApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EmployeeInfo empInfo = new EmployeeInfo();

        BindingList<EmployeeInfo> employeeList = new BindingList<EmployeeInfo>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                empInfo.EmployeeID = int.Parse(txtEmpID.Text);
                empInfo.FirstName = txtfname.Text;
                empInfo.LastName = txtLname.Text;
                empInfo.Position = txtposition.Text;

                DataTable dt = new DataTable();
                dt.Columns.Add("EmployeeID");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("Position");
                
                employeeList.Add(new EmployeeInfo(empInfo.EmployeeID, empInfo.FirstName, empInfo.LastName, empInfo.Position));
                dataGridView1.DataSource = employeeList;
                txtEmpID.Clear();
                txtfname.Clear();
                txtLname.Clear();
                txtposition.Clear();
                txtEmpID.Focus();

                 




            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string rowIndex = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dataGridView1.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}

