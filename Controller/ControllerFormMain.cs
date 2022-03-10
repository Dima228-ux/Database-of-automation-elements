using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database_of_automation_elements.Model;



namespace Database_of_automation_elements.Controller
{
    partial class ControllerFormMain
    {
        private Form1 _form;

        public ControllerFormMain(Form1 sender)
        {
            _form = sender;
        }

        public void Inicialize()
        {
            DBElectricalEquipment.Inicialize();
        }
    }
}
