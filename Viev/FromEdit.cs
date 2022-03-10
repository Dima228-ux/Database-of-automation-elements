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
    public partial class FromEdit : Form
    {
        ControllerFormEdit _controller;
        private int idEqupment, idEqupmentCategory;
        private string characteristicsEquipment;

        public FromEdit(int id, int idCategory, string descrition, string characteristics, string name, Image image)
        {
            InitializeComponent();
            textBoxName.Text = name;
            richTextBoxCharacteristics.Text = characteristics;
            richTextBoxDescription.Text = descrition;
            pictureBoxPicture.Image = new Bitmap(image);
            idEqupment = id;
            idEqupmentCategory = idCategory;
            characteristicsEquipment = characteristics;
        }

        private void FromEdit_Load(object sender, EventArgs e)
        {
            _controller = new ControllerFormEdit(this);
            //_controller.Y(id, descrition, characteristics, name, image);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxPicture.Image = null;
                    pictureBoxPicture.Image = new Bitmap(openFileDialog1.FileName);
                }
                catch
                {
                    MessageBox.Show("Файла не найдено");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            _controller.Edit(idEqupment,idEqupmentCategory,characteristicsEquipment);
        }
    }
}
