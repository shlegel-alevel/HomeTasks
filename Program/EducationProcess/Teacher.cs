using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess
{
    public class Teacher
    {
        private int _idOfTeacher;
        private string _firstNameOfTeacher;
        private string _lastNameOfTeacher;
        public TypeOfTeacher TypeOfTeacher { get; set; }
        public int MaxCountOfStudents { get; }


        public string FirstNameOfTeacher
        {
            get
            {
                return _firstNameOfTeacher;
            }
            set
            {
                if (value == "")
                {
                    throw new System.ArgumentException("Value can not be null");
                }
                else
                {
                    _firstNameOfTeacher = value;
                }
            }
        }

        public string LastNameOfTeacher
        {
            get
            {
                return _lastNameOfTeacher;
            }
            set
            {
                if (value == "")
                {
                    throw new System.ArgumentException("Value can not be null");
                }
                else
                {
                    _lastNameOfTeacher = value;
                }
            }
        }

        public string IdOfTeacher
        {
            get
            {
                return _idOfTeacher.ToString();
            }
            set
            {
                int id;
                if ((int.TryParse(value, out id)))
                {
                    _idOfTeacher = id;
                }
                else
                {
                    throw new System.ArgumentException("Value is not int");
                }
            }
        }

        public Teacher (int idOfTeacher, string firstNameOfTeacher = "Petya", string lastNameOfTeacher = "Petrov", TypeOfTeacher typeOfTeacher=TypeOfTeacher.Assistant)
        {
            IdOfTeacher = idOfTeacher.ToString();
            FirstNameOfTeacher = firstNameOfTeacher;
            LastNameOfTeacher = lastNameOfTeacher;
            TypeOfTeacher = typeOfTeacher;

            switch (TypeOfTeacher)
            {
                case TypeOfTeacher.Professor:
                    MaxCountOfStudents = 20;
                    break;
                case TypeOfTeacher.Lecturer:
                    MaxCountOfStudents = 15;
                    break;
                case TypeOfTeacher.Assistant:
                    MaxCountOfStudents = 5;
                    break;
            }
        }


    }
}
