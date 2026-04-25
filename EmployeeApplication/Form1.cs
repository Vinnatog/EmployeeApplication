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
       Employee emp = new Employee(0, "", "", "");

        BindingList<Employee> employeeList = new BindingList<Employee>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                emp.EmployeeID = int.Parse(txtEmpID.Text);
                emp.FirstName = txtfname.Text;
                emp.LastName = txtLname.Text;
                emp.Position = txtposition.Text;

                DataTable dt = new DataTable();
                dt.Columns.Add("EmployeeID");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("Position");
                
                
                bool exist = employeeList.Any(emp => emp.EmployeeID == emp.EmployeeID);
                if (exist)
                {
                    MessageBox.Show("Employee with this ID already exists.");
                }else 
                {
                    employeeList.Add(new Employee(emp.EmployeeID, emp.FirstName, emp.LastName, emp.Position));
                    dataGridView1.DataSource = employeeList;
                   
                }



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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

