using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database_of_automation_elements.Controller;

namespace Database_of_automation_elements.Model
{
    public partial class FromSearch : Form
    {
        private ControllerFormSearch _controller;
        public string NameEquipment;

        public FromSearch()
        {
            InitializeComponent();
        }

        private void FromSearch_Load(object sender, EventArgs e)
        {
            _controller = new ControllerFormSearch(this);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            NameEquipment= _controller.Search();
            
        }
    }
}
