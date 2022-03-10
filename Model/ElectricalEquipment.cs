using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_of_automation_elements.Model
{
    class ElectricalEquipment
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        static ElectricalEquipment()
        {
            DBElectricalEquipment.Inicialize();
        }
    }
}
