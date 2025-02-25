using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo
{
   public  class Program
    {
        static void Main(string[] args)
        {
            //=> Lambda /goesto
            List<Students> students = new List<Students>()
            {new Students{Rollno=71,StudName="Krushna",City="Pune",Age=23},
            new Students{Rollno=11,StudName="Diya",City="Mumbai",Age=20 },
            new Students{Rollno=12,StudName="Siya",City="Mumbai",Age=21},
            };
            Func<string> greet = () => "Hello World";
            string s = greet();
            Console.WriteLine(s);
            Func<int, int, int> addnos = (i, j) =>
                {
                    int ans = i + j;
                    return ans;
                };
            int a = addnos(1, 2);
            Console.WriteLine(a);

            Action<string> actiongreet = (username) =>
            {
                string str = string.Concat("Hello", username);
                Console.WriteLine(str);
            };
            actiongreet("Krushna");
            Predicate<int> evenorOdd = (num) =>
            {
                bool status = false;
                if (num % 2 == 0)
                {
                    status = true;
                }
                return status;
            };
            bool evenOrOddAns = evenorOdd(10);
            if (evenOrOddAns)
            {
                Console.WriteLine("The number is even");
            }
            else
            {
                Console.WriteLine("Its odd....");
            }

            var studnames = students.Select(x1 => x1.StudName);
            foreach(var item in studnames)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------------------------------");
            var sdatawithAge = students.Select(x => new { studage = x.Age, IntialLetter = x.StudName[0] });
            foreach (var item in sdatawithAge)
            {
                Console.WriteLine(item.IntialLetter + " " + item.studage);
            }
            Console.ReadLine();
        }

        }
    
}
