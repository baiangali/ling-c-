using System;
using System.Collections.Generic;
using System.Text;

namespace zadacha1
{
    class teacher : human
    {
       public List<string> subject { get; set; }
        public teacher() 
        {
            subject = new List<string>();
        
        }
    }
}
