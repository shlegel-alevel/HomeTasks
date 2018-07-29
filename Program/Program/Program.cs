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

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = InitializeGroup(100 + i, teachers[i], InitializeStudents(i + 10, $"firstNameOfGroup{i + 1}Students", $"lastNameOfGroup{i + 1}Students"));
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
                        ViewStudentsInCertainGroup(groups);
                        NavigateToBackMessage("Please press any button to continue");
                        break;
                    case "3":
                        groups = AddNewStudentToCertainGroup(groups);
                        NavigateToBackMessage("Please press any button to continue");
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


        public static bool IfCerteinIdGroupMatch(string id, Group[] groups)
        {
            bool ifCerteinIdGroupMatch = false;
            for (int i = 0; i < groups.Length; i++)
            {
                if (string.Equals(id.ToLower(), groups[i].IdGroup))
                {
                    ifCerteinIdGroupMatch = true;
                }
            }
            return ifCerteinIdGroupMatch;
        }


        public static string EnteringCertainGroupId(Group[] groups)
        {
            string idGroup;
            Console.WriteLine();
            Console.Write($"Please enter ID_group for adding a new student:");
            idGroup = Console.ReadLine();

            return idGroup;
        }


        public static void ViewStudentsInCertainGroup(Group[] groups)
        {
            string idGroup;
            bool exitAddingMenu = true;
            do
            {
                idGroup = EnteringCertainGroupId(groups);
                if (!IfCerteinIdGroupMatch(idGroup, groups))
                {
                    ErrorMessage($"There is not group with id = {idGroup}.");
                    exitAddingMenu = ReturnToPreviousMenu();
                }
                else
                {
                    for (int i = 0; i < groups.Length; i++)
                    {
                        if (groups[i].IdGroup == idGroup)
                        {
                            Console.WriteLine($"The list for stidents for group {groups[i].IdGroup}:");
                            ShowStudents(groups[i]);
                            exitAddingMenu = false;
                        }
                    }
                }
            }
            while (exitAddingMenu);
        }


        public static void ShowStudents(Group group)
        {
            for (int i = 0; i < group.Students.Length; i++)
            {
                Console.WriteLine($"{group.Students[i].IdOfStudent}. {group.Students[i].FirstNameOfStudent} {group.Students[i].LastNameOfStudent}");
            }
        }



        public static Group[] AddNewStudentToCertainGroup(Group[] groups)
        {
            string idGroup;
            bool exitAddingMenu = true;
            do
            {
                idGroup = EnteringCertainGroupId(groups);
                if (!IfCerteinIdGroupMatch(idGroup, groups))
                {
                    ErrorMessage($"There is not group with id = {idGroup}.");
                    exitAddingMenu = ReturnToPreviousMenu();
                }
                else
                {
                    for (int i = 0; i < groups.Length; i++)
                    {
                        if (groups[i].IdGroup == idGroup)
                        {
                            groups[i] = AddingNewStudent(groups[i]);
                            exitAddingMenu = false;
                        }
                    }

                }

            }
            while (exitAddingMenu);

            return groups;
        }

        public static Student EnterNewStudent(Group group)
        {
            string firstName, lastName;
            Student student=new Student();
            bool exit = true;
            do
            {
                try
                {
                    Console.Write("Please enter first name of a new student:");
                    firstName = Console.ReadLine();
                    Console.Write("Please enter last name of a new student:");
                    lastName = Console.ReadLine();
                    student = new Student(group.Students.Length + 1, firstName, lastName);
                    exit = false;
                }
                catch (ArgumentException ae)
                {
                    ErrorMessage(ae.GetType().Name + ":"+ ae.Message);
                }
            }

            while (exit);

            return student;
        }



        public static Group AddingNewStudent (Group group)
        {
            try
            {
                Student newStudent = EnterNewStudent(group);
                group.AddNewStudent(group.Curator, group.Students, newStudent);
                Console.Write("The student was added successfully.");
            }
            catch (IndexOutOfRangeException oe)
            {
                ErrorMessage(oe.GetType().Name + ":" + oe.Message);
            }

            return group;
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

        public static bool ReturnToPreviousMenu()
        {
            ConsoleKeyInfo key;
            bool exit = true;
            ErrorMessage("Please press any button to try again or press \"backspace\" to return to the menu");
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Backspace)
            {
                Console.Clear();
                ShowMainMenu();
                exit = false;
            }

            return exit;
        }

        public static void ErrorMessage(string message)
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();

        }
    }
}
