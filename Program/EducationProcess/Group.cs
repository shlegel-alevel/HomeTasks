using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationProcess
{
    public class Group
    {
        private int _idGroup;
        public Teacher Curator {get; set;}
        public Student[] Students {get; set;}

        public string IdGroup
        {
            get
            {
                return _idGroup.ToString();
            }
            set
            {
                int id;
                if ((int.TryParse(value, out id)))
                {
                    _idGroup = id;
                }
                else
                {
                    throw new ArgumentException("Value is not int");
                }
            }
        }

        public Group (int id, Teacher curator, Student []students)
        {
            IdGroup = id.ToString();
            Curator = curator;
            Students = students;
        }


        public void AddNewStudent(Teacher curator, Student [] students, Student student)
        {
            if (curator.MaxCountOfStudents<students.Length)
            {
                Student[] newStudents = new Student[students.Length+1];

                Array.Copy(students, newStudents, students.Length);

                newStudents[newStudents.Length - 1] = student;

                Students = new Student[newStudents.Length];

                Array.Copy(newStudents, Students, Students.Length);

            }
            else
            {
                throw new IndexOutOfRangeException("A new student can not be added to this group");
            }

        }








    }
}
