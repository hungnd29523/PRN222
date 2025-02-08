using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Single_Responsibility_Principle_Demo.Model
{
     class Book : IBook
    {
        public string Author { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
    }
}
