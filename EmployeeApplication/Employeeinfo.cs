using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeNamespace
{
    public class Employee
    {
        private int employeeID;
        private string firstName, lastname, position;
    }
    public class EmployeeInfo
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        
        public EmployeeInfo(int employeeID, string firstName, string lastName, string position)
        {
            this.EmployeeID = employeeID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Position = position;
            
        }
        public EmployeeInfo()
        {
            this.EmployeeID = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Position = "";
        }
       
    }
    
}


