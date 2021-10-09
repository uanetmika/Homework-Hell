using System;
using System.Collections.Generic;

enum Selectmenu { Login = 1 , Register = 2}



namespace ConsoleApp64 //เป็นโปรแกรมบันทึกชั่วโมงกิจกรรม
{
    class Program
    {
        static void Main(string[] args) 
        {
            Mainmenu();
        }
        static void Mainmenu() 
        {
            Console.WriteLine("Check activity hours  history");
            Console.WriteLine("--------------------------");
            Console.WriteLine("[1] Login ");
            Console.WriteLine("[2] Register ");
            Console.Write("Select menu : ");
            Selectmenu mn = (Selectmenu)(int.Parse(Console.ReadLine()));
            Register();
            Console.Clear();
        }
        static void selectmenu(Selectmenu mn) 
        {
            if (mn == Selectmenu.Login)
            { 
                Login();
            }
            if (mn == Selectmenu.Register)
            {
                Register();
            }
        }
        static void Register() 
        {
            Console.WriteLine("Register new person");
            Console.WriteLine("---------------------");
            yourtype();

        }
        static string yourtype() 
        {
            
            Console.WriteLine("[1] Student ");
            Console.WriteLine("[2] Employee ");
            Console.Write("Input your type : ");
            int t = int.Parse(Console.ReadLine());

            if (t == 1) 
            {
                informationStudent();
                Console.Clear();
                Login();
            }
            else if (t == 2) 
            {
                informationEmployee();
                Console.Clear();
                Login();
            }
            return Console.ReadLine();
        }
        static PersonList personlist;

        static void PreparePersonListWhenLoding() 
        {
            Program.personlist = new PersonList();
        }
        static Student creatnewstudent() 
        {
            return new Student(yourname(), yourpassword(), yourtype(), informationStudent());
        }
        static string yourname() 
        {
            Console.Write("Name : ");
            return Console.ReadLine();
        }
        static string yourpassword() 
        {
            Console.Write("Password : ");
            return Console.ReadLine();
        }
        static string informationStudent() 
        {
            Console.Write("Student ID : ");
            return Console.ReadLine();
        }
        static Employee creatnewemployee() 
        {
            return new Employee(yourname(), yourpassword(), yourtype(), informationEmployee());
        }
        static string informationEmployee() 
        {
            Console.Write("Employee ID : ");
            return Console.ReadLine();
        }
        static void Login() 
        {
            Console.WriteLine("Login Account");
            Console.WriteLine("---------------------");
            Console.Write("Name : ");
            string n = Console.ReadLine();
            Console.Write("Password : ");
            string pass = Console.ReadLine();
            Console.WriteLine("Your Type");
            Console.WriteLine("[1] Student ");
            Console.WriteLine("[2] Employee ");
            Console.Write("Select menu : ");
            int ty = int.Parse(Console.ReadLine());
            

            if (ty == 1) 
            {
                Console.WriteLine("Accouct Check Activity Hours For Student");
                Activity();
            }
            if (ty == 2) 
            {
                Console.WriteLine("Accouct Check Activity Hours For Employee");
                Activity();
            }
            
            
        }
        static void Activity() 
        {
            Console.WriteLine("Activity Hours : 0");
            Console.Clear();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Add activity hours?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            Console.Write("Select menu : ");
            int smn = int.Parse(Console.ReadLine());
            Console.Clear();

            if (smn == 1)
            {
                Console.Write("Please input activity hours : ");
                int h = int.Parse(Console.ReadLine());
                Console.Write("Activity Hours : ");
                Console.Write(h);
            }
            else if (smn == 2) 
            {
                Console.Write("Good Bye");
            } 
        }
      
    }

    class Person 
    {
        public string name;
        public string password;
        public string type;
        public Person(string valuename, string valuepassword, string valuetype) 
        {
            name = valuename;
            password = valuepassword;
            type = valuetype;
        }
    }
    class Student : Person 
    {
        public string name;
        public string password;
        public string StudentID;
        public string type;

        public Student(string valuename, string valuepassword, string valueStudentID, string valuetype) : base(valuename, valuepassword, valuetype) 
        {
            name = valuename;
            password = valuepassword;
            StudentID = valueStudentID;
            type = valuetype;
        }
    }
    class Employee : Person 
    {
        public string name;
        public string password;
        public string EmployeeID;
        public string type;

        public Employee(string valuename, string valuepassword, string valueEmployeeID, string valuetype) : base(valuename, valuepassword, valuetype)
        {
            name = valuename;
            password = valuepassword;
            EmployeeID = valueEmployeeID;
            type = valuetype;
        }
    }
    class PersonList 
    {
        private List<Person> personList;

        public PersonList() 
        {
            this.personList = new List<Person>();
        }
        public void AddPerson(Person person) 
        {
            this.personList.Add(person);
        }
    }

}
