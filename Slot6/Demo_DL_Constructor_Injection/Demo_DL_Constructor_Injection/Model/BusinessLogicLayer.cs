using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DL_Constructor_Injection.Model
{
    public class BookManager
    {
        public IBookReader bookReader;
        // Constructor Injection
        public BookManager(IBookReader reader)
        {
            bookReader = reader;
        }
        //------------------------
        public void ReadBooks()
        {
            bookReader.ReadBooks();
        }
    }

}
