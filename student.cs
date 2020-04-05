using System;
using System.Collections.Generic;
using System.Text;

namespace zadacha1
{
    class Student:human
    {
        
        public List<string> subject { get; set; }
        public Student()
        {
            subject = new List<string>();
        }
    }
}
