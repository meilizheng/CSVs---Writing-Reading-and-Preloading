using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLibary;

namespace CSVs___Writing_Reading_and_Preloading
{
    public class Student
    {
        string _firstName;
        string _lastName;
        int csiGrade;
        int genEdGrade;

        public Student()
        {

        }

        public Student(string firstName, string lastName, int csiGrade, int genEdGrade)
        {
            _firstName = firstName;
            _lastName = lastName;
            this.csiGrade = csiGrade;
            this.genEdGrade = genEdGrade;
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public int CsiGrade { get => csiGrade; set => csiGrade = value; }
        public int GenEdGrade { get => genEdGrade; set => genEdGrade = value; }
        public double Average { get => (CsiGrade + GenEdGrade) / 2; }
    }


    
}
