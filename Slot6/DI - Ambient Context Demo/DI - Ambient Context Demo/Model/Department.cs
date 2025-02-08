using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DI___Ambient_Context_Demo.Model;

namespace DI___Ambient_Context_Demo.Model
{
    public interface IDepartment

    {

        int DeptId { get; set; }

        string DeptName { get; set; }

    }

    //--------------------------

    public class Department : IDepartment

    {

        public int DeptId { get; set; }

        public string DeptName { get; set; }

    }

    //--------------------------

    public class Engineering : Department

    {

        public Engineering()

        {

            DeptName = "Engineering";

        }

    }

    //--------------------------

    public class Marketing : Department

    {

        public Marketing()

        {

            DeptName = "Marketing";

        }

    }
}
