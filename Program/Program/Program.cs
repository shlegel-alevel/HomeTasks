using System;
using EducationProcess;
using Data;
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
            int numberOfGroups = 7;
            int numberOfTeachers = 10;


            Teacher[] teachers = InitializeTeachers(numberOfTeachers);

            Group[] groups = new Group[numberOfGroups];

            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = InitializeGroup(100 + i, teachers[i], InitializeStudents(i+2));
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
                        groups = AddNewStudentMenuLogic(groups);
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

        public static Group[] AddNewStudentMenuLogic(Group[] groups)
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
                    groups = AddNewStudentToCertainGroup(idGroup, groups);
                    exitAddingMenu = false;
                }

            }
            while (exitAddingMenu);

            return groups;
        }

        public static Group[] AddNewStudentToCertainGroup(string idGroup, Group [] groups)
        {
            string firstName, lastName;
            Student student = new Student();
            firstName = EnterNewStudentParameters(out lastName);
            try
            {

                
                for (int i = 0; i < groups.Length; i++)
                {
                    if (groups[i].IdGroup == idGroup)
                    {
                        student = new Student(groups[i].Students.Length + 1, firstName, lastName);
                        groups[i].AddNewStudent(groups[i].Curator, groups[i].Students, student);
                        Console.Write($"The student was added successfully to group {groups[i].IdGroup}");
                    }
                }
            }
            catch (ArgumentException ae)
            {
                ErrorMessage(ae.GetType().Name + ":" + ae.Message);
            }
            catch (IndexOutOfRangeException oe)
            {
                ErrorMessage(oe.GetType().Name + ":" + oe.Message);
                for (int i = 0; i < groups.Length; i++)
                {
                    if (IfStudentCanBeAdded(groups[i]))
                    {
                        groups[i].AddNewStudent(groups[i].Curator, groups[i].Students, student);
                        Console.WriteLine($"New student was added to group {groups[i].IdGroup}");
                        break;
                    }
                }
            }

            return groups;
        }

        public static string EnterNewStudentParameters(out string lastName)
        {
            string firstName;
                    Console.Write("Please enter the first name of a new student:");
                    firstName = Console.ReadLine();
                    Console.Write("Please enter the last name of a new student:");
                    lastName = Console.ReadLine();

            return firstName;
        }

        public static bool IfStudentCanBeAdded (Group group)
        {
            bool ifStudentCanBeAdded=false;
                if (group.Students.Length < group.Curator.MaxCountOfStudents)
                {
                    ifStudentCanBeAdded = true;
                }
            return ifStudentCanBeAdded;
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

        public static Student[] InitializeStudents(int numberOfStudents)
        {
            var firstNames = Enum.GetValues(typeof(FirstNames));
            var lastNames = Enum.GetValues(typeof(LastNames));
            Student[] students = new Student[numberOfStudents];

            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student(i + 1, $"{firstNames.GetValue(i)}", $"{lastNames.GetValue(i + 1)}");
            }

            return students;
        }

        public static Teacher[] InitializeTeachers(int numberOfTeachers)
        {
            var firstNames = Enum.GetValues(typeof(FirstNames));
            var lastNames = Enum.GetValues(typeof(LastNames));


            Teacher[] teachers = new Teacher[numberOfTeachers];

            for (int i = 0; i < teachers.Length; i++)
            {
                if (i > 5)
                {
                    teachers[i] = new Teacher(i + 1, $"{firstNames.GetValue(i)}", $"{lastNames.GetValue(i+1)}", TypeOfTeacher.Professor);
                }
                else if ((i > 2) && (i <= 5))
                {
                    teachers[i] = new Teacher(i + 1, $"{firstNames.GetValue(i)}", $"{lastNames.GetValue(i + 1)}", TypeOfTeacher.Lecturer);
                }
                else
                {
                    teachers[i] = new Teacher(i + 1, $"{firstNames.GetValue(i)}", $"{lastNames.GetValue(i + 1)}");
                }

            }
            return teachers;
        }

        public static Group InitializeGroup(int idGroup, Teacher teacher, Student[] students)
        {
            Group group = new Group(idGroup, teacher, students);

            return group;
        }
    }
}
