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
                int empid = int.Parse(txtEmpID.Text);
                emp.FirstName = txtfname.Text;
                emp.LastName = txtLname.Text;
                emp.Position = txtposition.Text;

                DataTable dt = new DataTable();
                dt.Columns.Add("EmployeeID");
                dt.Columns.Add("FirstName");
                dt.Columns.Add("LastName");
                dt.Columns.Add("Position");

                
                

                if (!int.TryParse(txtEmpID.Text, out empid)|| empid <= 0)
                {
                    MessageBox.Show("Please enter a valid Employee ID.");
                    txtEmpID.Clear();
                    txtfname.Clear();
                    txtLname.Clear();
                    txtposition.Clear();
                    txtEmpID.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtfname.Text))
                {
                    MessageBox.Show("Please enter First Name.");
                    txtEmpID.Clear();
                    txtfname.Clear();
                    txtLname.Clear();
                    txtposition.Clear();
                    txtEmpID.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtLname.Text))
                {
                    MessageBox.Show("Please enter Last Name.");
                    txtEmpID.Clear();
                    txtfname.Clear();
                    txtLname.Clear();
                    txtposition.Clear();
                    txtEmpID.Focus();
                    return;
                }
                else if (string.IsNullOrEmpty(txtposition.Text))
                {
                    MessageBox.Show("Please enter Position.");
                    txtposition.Clear();
                    txtEmpID.Focus();
                    return;
                }
                else if (double.TryParse(txtfname.Text, out _) || double.TryParse(txtLname.Text, out _)|| double.TryParse(txtposition.Text, out _))
                {
                    MessageBox.Show("First Name, Last Name, and Position cannot be numeric. Please enter valid text.");
                    txtEmpID.Clear();
                    txtfname.Clear();
                    txtLname.Clear();
                    txtposition.Clear();
                    txtEmpID.Focus();
                    return;
                }

                bool isDuplicate = employeeList.Any(emp => emp.EmployeeID == empid);
                if (isDuplicate)
                {
                    MessageBox.Show("Employee ID already exists. Please enter a unique Employee ID.");
                    txtEmpID.Clear();
                    txtfname.Clear();
                    txtLname.Clear();
                    txtposition.Clear();
                    txtEmpID.Focus();
                    return;
                }
                else
                {
                    dataGridView1.DataSource = employeeList;
                    employeeList.Add(new Employee(empid, emp.FirstName, emp.LastName, emp.Position));
                    emp.EmployeeID = empid;
                    emp.FirstName = txtfname.Text; 
                    emp.LastName = txtLname.Text; 
                    emp.Position = txtposition.Text;
                    txtEmpID.Clear();
                    txtfname.Clear();
                    txtLname.Clear();
                    txtposition.Clear();
                    txtEmpID.Focus();
                    return;
                }
                  }

            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input: " + ex.Message + "\nPlease enter valid data.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message + "\nPlease try again.");
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control currentControl = this.ActiveControl;
                if (currentControl is TextBox)
                {
                    e.SuppressKeyPress = true;
                    this.SelectNextControl(currentControl, true, true, true, true);
                    e.SuppressKeyPress = true;
                }
                else if (currentControl is Button)
                {

                }
            }
        }
    }
}
    


