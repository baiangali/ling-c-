using System;
using System.Linq;
using System.Collections.Generic;
namespace zadacha1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            database db = database.GetInstance();
            List<Student> students = new List<Student>
            {
                new Student {Name="Том",  subject = new List<string> {"Aнглийский", "Немецкий" }},
                new Student {Name="Боб",  subject = new List<string> {"Aнглийский", "Французский" }},
                new Student {Name="Михаил",  subject = new List<string> {"Aнглийский", "Испанский" }},
                new Student {Name="Элис",  subject= new List<string> {"Испанский", "Немецкий" }}
            };

            List<teacher> teachers = new List<teacher>
            { 
                new teacher { Name = "Иван", subject = new List<string>{ "Aнглийский" } },
                new teacher { Name = "Михаил", subject = new List<string>{ "Французский" } },
                new teacher { Name = "Стефан", subject = new List<string>{ "Немецкий" } },
                new teacher { Name = "Стивен", subject = new List<string>{ "Испанский" } }

            };

            var selectedAll = from stud in students
                                from sub in stud.subject
                                group sub by sub;
            foreach (var student in selectedAll)
                Console.WriteLine(student.Key + " " + student.Count() + "students");

            Console.WriteLine("-----------------------------");

            var selected = from x in (from s in students
                                      from sub in s.subject
                                      select new { sub, s.Name })
                                      group x by x.sub;
            foreach (var sub in selected)
            {
                Console.WriteLine(sub.Key);
                foreach (var item in sub)
                {
                    Console.WriteLine("    " + item.Name);
                }
            }
            
            Console.WriteLine("-----------------------------");

            var res = from t in (from t in teachers
                                 from s in students
                                 from st in s.subject
                                 from st1 in t.subject
                                 where st == st1 
                                 select new { tachname = t.Name, staname = s.Name, st2 = st })
                      group t by t.st2;
                     
                     
             
            foreach (var i in res)
            {
                Console.WriteLine($"Subject   : {i.Key}");
                foreach (var item in i)
                {
                    Console.WriteLine("Teacher name:  " + item.tachname);
                    foreach (var item1 in i)
                    {
                        Console.WriteLine("        Student name:  " + item1.staname);
                    }
                }
            }
            Console.WriteLine("-----------------------------");

            //var result = from s in students
            //             from tt in teachers
            //             from subc in s.subject
            //             group subc by s.subject into g
            //             select new
            //             {
            //                 t = g.Key,
            //                 c = g.Count(),
            //                 u = from tt in g select tt

            //             };
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.t}{item.c}");
            //    foreach (teacher named in item.u)
            //    {
            //        Console.WriteLine(named.Name);
            //    }
            //}
                        

                         
                 
                         


        }
    }

    
}
