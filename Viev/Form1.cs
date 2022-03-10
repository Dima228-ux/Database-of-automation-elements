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
using Database_of_automation_elements.Model;

namespace Database_of_automation_elements
{//Почитать книгу Чистый код!!!!!!!!!!!
    public partial class Form1 : Form
    {
        private ControllerFormMain _controller;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxCategories.SelectedIndexChanged -= comboBoxCategories_SelectedIndexChanged;
            _controller = new ControllerFormMain(this);
            _controller.Inicialize();
            _controller.SelectCategories();
            comboBoxCategories.SelectedIndex = -1;
            comboBoxCategories.SelectedIndexChanged += comboBoxCategories_SelectedIndexChanged;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _controller.OpenFormAdd();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            _controller.OpenFormSearch();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            _controller.Edit();
        }

        private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
           dataGridViewElectricalEquipment.SelectionChanged -= dataGridViewElectricalEquipment_SelectionChanged;
            _controller.SelectElectricalEquipment();
            dataGridViewElectricalEquipment.SelectionChanged += dataGridViewElectricalEquipment_SelectionChanged;
        }

        private void dataGridViewElectricalEquipment_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewElectricalEquipment.SelectedCells.Count == 0)
                return;
            _controller.CellClick();
        }

        private void buttonDeleteElectricalEquipment_Click(object sender, EventArgs e)
        {
            _controller.DeleteElectricalEquipment();
        }
    }
}
