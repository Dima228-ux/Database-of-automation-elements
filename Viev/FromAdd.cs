using Database_of_automation_elements.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_of_automation_elements.Model
{
    public partial class FromAdd : Form
    {
        private ControllerFormAdd controller;
        public FromAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            controller = new ControllerFormAdd(this);
            controller.SelectCategories();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxImage.Image = new Bitmap(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("Файла не найдено");
                }
            }
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            controller.Add();
            
        }
    }
}
