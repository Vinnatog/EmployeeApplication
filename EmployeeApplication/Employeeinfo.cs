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

        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Position
        {
            get { return position; }
            set { position = value; }
        } 
        public Employee(int employeeID, string firstName, string lastname, string position)
        {
            this.employeeID = employeeID;
            this.firstName = firstName;
            this.lastname = lastname;
            this.position = position;
        }
        public Employee()
        {
            this.employeeID = 0;
            this.firstName = "";
            this.lastname = "";
            this.position = "";
           
           
        }


    }
}



    



