using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_of_automation_elements.Model
{
    class GoodsCharacteristics
    {
        public int Id { get; set; }
        public int IdElectricalEquipment { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int IdCharacteristics { get; set; }
        public string Characteristics { get; set; }
        public string Value { get; set; }

        static GoodsCharacteristics()
        {
            DBElectricalEquipment.Inicialize();
        }


    }
}
