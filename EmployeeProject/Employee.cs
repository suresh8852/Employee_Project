using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeProject
{
    public class Employee
    {
        string employeeName;
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }
        string department;
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        string skills;
        public string Skills
        {
            get { return skills; }
            set { skills = value; }
        }
        char gender;
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        string stream;
        public string Stream
        {
            get { return stream; }
            set { stream = value; }
        }
    }
}