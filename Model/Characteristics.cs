using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_of_automation_elements.Model
{
    class Characteristics
    {
        public int Id { get; set; }
        public string Characteristic { get; set; }

        static Characteristics()
        {
            DBElectricalEquipment.Inicialize();
        }

        public override string ToString()
        {
            return Characteristic;
        }
    }
}
