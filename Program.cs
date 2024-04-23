using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlingEmployee
{
    public class Employee 
    {
        public string Name { get; set; }    
        public int Age { get; set; } 
        public string Department { get; set; } 

        public Employee(string name,int age,string dept) 
        {
            Name = name;
            Age = age;
            Department = dept;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                List<Employee> list = new List<Employee>(); 
                string[] strings = { "Thanay,23,Development", "Saikat,20,Testing", "Lakshmi,25,HR", "Yashwanth,24,Management", "Gowtham,28,R & D" };

                File.WriteAllLines("employee.csv",strings);

                using (StreamReader streamReader = new StreamReader("employee.csv"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] employeeString = streamReader.ReadLine().Split(',');
                        Employee employee = new Employee(employeeString[0], int.Parse(employeeString[1]), employeeString[2]);
                        list.Add(employee);
                    }
                }

                foreach (Employee employee in list)
                {
                    Console.WriteLine($"Name = {employee.Name}, Age = {employee.Age}, Department = {employee.Department}\n");
                }
            }
            catch(Exception ex)
            
            {
                Console.WriteLine(ex.Message);   
            }
        }
    }
}
