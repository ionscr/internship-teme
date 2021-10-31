using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Student { FirstName= "Andreo", LastName= "Keo", Age= 18, Country= "Romania"};
            var s2 = new Student { FirstName = "Opiod", LastName = "Iosde", Age = 28, Country = "Russia" };
            var s3 = new Student { FirstName = "Oklio", LastName = "Werf", Age = 18, Country = "Romania" };
            var students = new List<Student> { s1,s2,s3};
            var filteredByCountry = from s in students
                                    where s.Country == "Romania"
                                    select s.FirstName + " " + s.LastName;
            foreach (var fs in filteredByCountry) Console.WriteLine(fs.ToString());
            Console.WriteLine();
            var groupByAge = from s in students
                             orderby s.Age descending
                             group s by s.Age into sgroup
                             select sgroup;
                             
                             
            foreach (var fs in groupByAge)
            {
                Console.WriteLine(fs.Key + " " + fs.Count());
                foreach (var s in fs) Console.WriteLine(s.FirstName + " " + s.LastName);
                Console.WriteLine();
            }

        }
    }
}
