using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_of_automation_elements.Model
{
    class Categories
    {
        public int ID { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return Category;
        }
    }
}
