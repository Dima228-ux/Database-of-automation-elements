using Database_of_automation_elements.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_of_automation_elements.Controller
{
    class ControllerFormEdit
    {
        private FromEdit _form;

        public ControllerFormEdit(FromEdit sender)
        {
            _form = sender;
        }

        public void Edit(int id, int idCategory, string chactericticEquipment)
        {
            if (_form.textBoxName.Text.Trim() == string.Empty || _form.richTextBoxDescription.Text == string.Empty || _form.richTextBoxCharacteristics.Text == string.Empty || _form.pictureBoxPicture.Image == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            string name = _form.textBoxName.Text;
            string description = _form.richTextBoxDescription.Text;
            string image = null;
            if (_form.openFileDialog1.FileName != "openFileDialog1")
                image = Convert.ToBase64String(File.ReadAllBytes(_form.openFileDialog1.FileName));

            string[] separator = { ",", "\n" };
            Dictionary<string, string> newchacterictics = new Dictionary<string, string>();
            Dictionary<string, string> oldchacterictics = new Dictionary<string, string>();

            string[] newcharacterictic = _form.richTextBoxCharacteristics.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] oldcharacterictic = chactericticEquipment.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (int i = 0; i < newcharacterictic.Length - 1; i++)
                {
                    newchacterictics.Add(newcharacterictic[i], newcharacterictic[i + 1]);
                    i++;
                }

                for (int i = 0; i < oldcharacterictic.Length - 1; i++)
                {
                    oldchacterictics.Add(oldcharacterictic[i], oldcharacterictic[i + 1]);
                    i++;
                }

                if (DBElectricalEquipment.UpdateElectricalEquipment(id, idCategory, description, image, name) > 0 && DBElectricalEquipment.UpdateCharacteristics(id, idCategory, newchacterictics, oldchacterictics) > 0)
                {
                    MessageBox.Show("Запись отредактирована");
                    _form.Close();
                }
                else
                {
                    MessageBox.Show("Запись не отредактирована");
                }
            }
            catch
            {
                MessageBox.Show("Вы ввели одинаковые значения");
            }
        }

    }
}
