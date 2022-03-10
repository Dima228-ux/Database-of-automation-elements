using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database_of_automation_elements.Model;

namespace Database_of_automation_elements.Controller
{
    class ControllerFormAdd
    {
        private FromAdd _form;
        private List<Categories> _categories = new List<Categories>();

        public ControllerFormAdd(FromAdd sender)
        {
            _form = sender;
        }

        public void SelectCategories()
        {
            _categories.Clear();
            DBElectricalEquipment.SelectAllCategories(_categories);
            _form.comboBoxCategories.DataSource = null;
            _form.comboBoxCategories.DataSource = _categories;
        }

        public void Add()
        {
            if (_form.textBoxName.Text.Trim() == string.Empty || _form.richTextBoxDescription.Text.Trim() == string.Empty || _form.richTextBoxChacterictics.Text.Trim() == string.Empty || _form.pictureBoxImage.Image == null)
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            string name = _form.textBoxName.Text;
            string description = _form.richTextBoxDescription.Text;
            string image = Convert.ToBase64String(File.ReadAllBytes(_form.openFileDialog1.FileName));
            string[] separator = { ",", "\n" };
            int idCategory = ((Categories)_form.comboBoxCategories.SelectedItem).ID;
            Dictionary<string, string> chacterictics = new Dictionary<string, string>();

            string[] characterictic = _form.richTextBoxChacterictics.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                for (int i = 0; i < characterictic.Length - 1; i++)
                {
                    chacterictics.Add(characterictic[i], characterictic[i + 1]);
                    i++;
                }

                if (DBElectricalEquipment.AddCharacteristics(DBElectricalEquipment.AddElectricalEquipment(idCategory, description, image, name), chacterictics) == 1)
                    MessageBox.Show("Запись добавлена");

                else
                    MessageBox.Show("Запись не добавлена");
            }
            catch
            {
                MessageBox.Show("Вы ввели одинаковые значения");

            }
        }
    }
}
