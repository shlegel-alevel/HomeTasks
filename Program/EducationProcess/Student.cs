using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess
{
    public class Student
    {
        private int _idOfStudent;
        private string _firstNameOfStudent;
        private string _lastNameOfStudent;


        public string FirstNameOfStudent
        {
            get
            {
                return _firstNameOfStudent;
            }
            set
            {
                if (value == "")
                {
                    throw new System.ArgumentException("Value can not be null");
                }
                else
                {
                    _firstNameOfStudent = value;
                }
            }
        }

        public string LastNameOfStudent
        {
            get
            {
                return _lastNameOfStudent;
            }
            set
            {
                if (value == "")
                {
                    throw new System.ArgumentException("Value can not be null");
                }
                else
                {
                    _lastNameOfStudent = value;
                }
            }
        }

        public string IdOfStudent
        {
            get
            {
                return _idOfStudent.ToString();
            }
            set
            {
                int id;
                if ((int.TryParse(value, out id)))
                {
                    _idOfStudent = id;
                }
                else
                {
                    throw new System.ArgumentException("Value is not int");
                }
            }
        }

        public Student (int idOfStudent, string firstNameOfStudent="Ivan", string lastNameOfStudent="Ivanov")
        {
            IdOfStudent = idOfStudent.ToString();
            FirstNameOfStudent = firstNameOfStudent;
            LastNameOfStudent = lastNameOfStudent;
        }



    }
}
