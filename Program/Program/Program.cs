using System;
using EducationProcess;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;
            int numberOfGroups = 3;
            int numberOfTeachers = 7;



            Student[] studentsGroup1 = InitializeStudents(9, "firstNameOfGroup1Students", "lastNameOfGroup1Students");
            Student[] studentsGroup2 = InitializeStudents(10, "firstNameOfGroup2Students", "lastNameOfGroup2Students");
            Student[] studentsGroup3 = InitializeStudents(12, "firstNameOfGroup3Students", "lastNameOfGroup3Students");


            Teacher[] teachers = InitializeTeachers(numberOfTeachers, "firstNameOfCurator", "lastNameOfCurator");

            Group[] groups = new Group[numberOfGroups];

            for (int i=0; i< groups.Length; i++)
            {
                groups[i] = InitializeGroup(100 + i, teachers[i], InitializeStudents(9 + i, $"firstNameOfGroup{i + 1}Students", $"lastNameOfGroup{i + 1}Students"));
            }

            do
            {
                
                ShowMainMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        ViewInfoAboutGroups(groups);
                        NavigateToBackMessage("Please press any button to continue");
                        break;
                    case "2":
                        //Show information certain groups
                        break;
                    case "3":
                        //Add a new student to certain group
                        break;
                    case "4":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid symbols: you should enter only [1], [2], [3], [4].");
                        NavigateToBackMessage("Please press any button to continue");
                        break;
                }

            }
            while (exit);


        }

        public static string GetCerteinIdGroup (string id, Group[] groups)
        {
            string idGroup = "";
            for (int i = 0; i < groups.Length; i++)
            {
                if (string.Equals (id.ToLower(), groups[i].IdGroup))
                {
                    idGroup = groups[i].IdGroup;
                }
            }

            return idGroup;
        }




        public static void AddNewUserToCertainGroup(Group[] groups)
        {
            for (int i = 0; i < groups.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"ID_group: {groups[i].IdGroup}");
                Console.WriteLine($"Curator: {groups[i].Curator.FirstNameOfTeacher} {groups[i].Curator.LastNameOfTeacher}");
                Console.WriteLine($"Number of students: {groups[i].Students.Length}");
                Console.WriteLine($"Maximum number of possible Students: {groups[i].Curator.MaxCountOfStudents}");

            }
        }


        public static void ViewInfoAboutGroups (Group [] groups)
        {
            for (int i=0; i<groups.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"ID_group: {groups[i].IdGroup}");
                Console.WriteLine($"Curator: {groups[i].Curator.FirstNameOfTeacher} {groups[i].Curator.LastNameOfTeacher}");
                Console.WriteLine($"Number of students: {groups[i].Students.Length}");
                Console.WriteLine($"Maximum number of possible Students: {groups[i].Curator.MaxCountOfStudents}");

            }
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("Welcome to the system. Please select what you would you like to do:");
            Console.WriteLine("[1] View information about groups;");
            Console.WriteLine("[2] View information about students in certain group;");
            Console.WriteLine("[3] Add a new student to certain group; ");
            Console.WriteLine("[4] Exit");
            Console.Write("Please make your choise: ");
            
        }


        public static Student[] InitializeStudents (int numberOfStudents, string firstName, string lastName)
        {
            Student[] students = new Student[numberOfStudents];

            for (int i=0; i<students.Length; i++)
            {
                students[i] = new Student(i + 1, $"{firstName}{i}", $"{lastName}{i}");
            }

            return students;
        }

        public static Teacher [] InitializeTeachers (int numberOfTeachers, string firstName, string lastName )
        {
            Teacher [] teachers = new Teacher[numberOfTeachers];

            for (int i = 0; i < teachers.Length; i++)
            {
                if (i<3)
                {
                    teachers[i] = new Teacher(i + 1, $"{firstName}{i+1}", $"{lastName}{i+1}", TypeOfTeacher.Professor);
                }
                else if ((i>=3) && (i<7))
                {
                    teachers[i] = new Teacher(i + 1, $"{firstName}{i+1}", $"{lastName}{i+1}", TypeOfTeacher.Lecturer);
                }
                else
                {
                    teachers[i] = new Teacher(i + 1, $"{firstName}{i}", $"{lastName}{i}");
                }

            }
            return teachers;
        }

        public static Group  InitializeGroup (int idGroup, Teacher teacher, Student [] students)
        {
            Group group = new Group(idGroup, teacher, students);

            return group;
        }

        public static void NavigateToBackMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

        }

    }
}
