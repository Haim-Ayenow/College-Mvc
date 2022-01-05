using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace College.Models
{
    public class Student
    {
        public string FName;
        public string LName;
        public DateTime BirthDay;
        public string Email;
        public int YearSchool;

        public Student(string fName, string lName, DateTime birthDay, string email, int yearSchool)
        {
            FName = fName;
            LName = lName;
            BirthDay = birthDay;
            Email = email;
            YearSchool = yearSchool;
        }
    }
}