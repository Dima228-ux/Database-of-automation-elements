using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database_of_automation_elements.Model;



namespace Database_of_automation_elements.Controller
{
    partial class ControllerFormMain
    {
        private List<Categories> _categories = new List<Categories>();
        private List<ElectricalEquipment> _electricalEquipment = new List<ElectricalEquipment>();
        private List<GoodsCharacteristics> _goods = new List<GoodsCharacteristics>();
        private List<Characteristics> _charateristics = new List<Characteristics>();

        public void OpenFormAdd()
        {
            FromAdd a = new FromAdd();
            a.ShowDialog();
            if (_form.comboBoxCategories.SelectedItem != null)
                SelectElectricalEquipment();
        }

        public void OpenFormSearch()
        {
            FromSearch s = new FromSearch();
            s.ShowDialog();
            if (s.NameEquipment != null)
                Search(s.NameEquipment);
        }

        public void Edit()
        {
            if (_form.textBoxTitle.Text.Trim() == string.Empty || _form.richTextBoxDescription.Text == string.Empty || _form.richTextBoxCharacterisrics.Text == string.Empty || _form.pictureBoxPicture.Image == null)
            {
                MessageBox.Show("Выберите обородувание,которое хотите редактировать");
                return;
            }
            ElectricalEquipment eq = (ElectricalEquipment)_form.dataGridViewElectricalEquipment.Rows[_form.dataGridViewElectricalEquipment.SelectedCells[0].RowIndex].DataBoundItem;

            FromEdit e = new FromEdit(eq.Id, eq.IdCategory, _form.richTextBoxDescription.Text, _form.richTextBoxCharacterisrics.Text, _form.textBoxTitle.Text, _form.pictureBoxPicture.Image);
            e.ShowDialog();
            SelectElectricalEquipment();
        }

        public int CellClick()
        {
            if (_form.dataGridViewElectricalEquipment.SelectedCells.Count == 0)
            {
                MessageBox.Show("Выберите ячейку");
                return 0;
            }

            _form.richTextBoxCharacterisrics.Text = null;
            _form.textBoxTitle.Text = null;
            _form.richTextBoxDescription.Text = null;
            _form.pictureBoxPicture.Image = null;
            ElectricalEquipment eq = (ElectricalEquipment)_form.dataGridViewElectricalEquipment.Rows[_form.dataGridViewElectricalEquipment.SelectedCells[0].RowIndex].DataBoundItem;
            var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(_electricalEquipment.Find(x => x.Id == eq.Id).Image)));
            _form.textBoxTitle.Text = _electricalEquipment.Find(x => x.Id == eq.Id).Name;
            _form.richTextBoxDescription.Text = _electricalEquipment.Find(x => x.Id == eq.Id).Description;
            _form.pictureBoxPicture.Image = new Bitmap(image);

            foreach (var item in _goods)
            {
                if (item.IdElectricalEquipment == eq.Id)
                    _form.richTextBoxCharacterisrics.Text += $" {item.Characteristics},{item.Value}" + "\n";
            }
            return eq.Id;
        }

        public void Search(string nameEquipment)
        {
            if (nameEquipment != null)
            {
                _form.richTextBoxCharacterisrics.Text = null;
                _form.textBoxTitle.Text = null;
                _form.richTextBoxDescription.Text = null;
                _form.pictureBoxPicture.Image = null;

                _categories.Clear();
                _electricalEquipment.Clear();
                _charateristics.Clear();
                _goods.Clear();
                DBElectricalEquipment.Search(nameEquipment, _electricalEquipment, _charateristics, _goods, _categories);

                _form.dataGridViewElectricalEquipment.DataSource = null;
                _form.dataGridViewElectricalEquipment.DataSource = _electricalEquipment;

                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Id)].Visible = false;
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Category)].Visible = false;
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.IdCategory)].Visible = false;
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Name)].HeaderText = "Название";
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Description)].HeaderText = "Описание";
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Image)].HeaderText = "Фотография";

                if (_electricalEquipment.Count == 0)
                {
                    _form.dataGridViewElectricalEquipment.DataSource = null;
                    MessageBox.Show("По вашему запросу ничего не найдено");
                }

            }

        }

        public void DeleteElectricalEquipment()
        {
            int idElectricalEquipment = CellClick();
            string titleElectricalEquipment = _form.textBoxTitle.Text;
            DialogResult result = MessageBox.Show($"Хотите удалить электрооборудование {titleElectricalEquipment}?", "Потверждение", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
                return;

            if (idElectricalEquipment > 0)
            {
                DBElectricalEquipment.DeleteElectricalEquipment(idElectricalEquipment);
                SelectElectricalEquipment();
            }
            else
                MessageBox.Show("Выбирите ячейку которую хотите удалить");
        }

        public void SelectCategories()
        {
            _categories.Clear();
            DBElectricalEquipment.SelectAllCategories(_categories);
            _form.comboBoxCategories.DataSource = null;
            _form.comboBoxCategories.DataSource = _categories;
        }

        public bool SelectElectricalEquipment()
        {
            bool check = false;
            if (DBElectricalEquipment.SeletElectricalEquipment(((Categories)_form.comboBoxCategories.SelectedItem).ID))
            {
                _form.richTextBoxCharacterisrics.Text = null;
                _form.textBoxTitle.Text = null;
                _form.richTextBoxDescription.Text = null;
                _form.pictureBoxPicture.Image = null;

                _categories.Clear();
                _electricalEquipment.Clear();
                _charateristics.Clear();
                _goods.Clear();
                DBElectricalEquipment.Select(((Categories)_form.comboBoxCategories.SelectedItem).ID, _electricalEquipment, _charateristics, _goods, _categories);
                check = true;

                _form.dataGridViewElectricalEquipment.DataSource = null;
                _form.dataGridViewElectricalEquipment.DataSource = _electricalEquipment;
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Id)].Visible = false;
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Category)].Visible = false;
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.IdCategory)].Visible = false;
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Name)].HeaderText = "Название";
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Description)].HeaderText = "Описание";
                _form.dataGridViewElectricalEquipment.Columns[nameof(ElectricalEquipment.Image)].HeaderText = "Фотография";
            }
            else
            {
                _form.richTextBoxCharacterisrics.Text = null;
                _form.textBoxTitle.Text = null;
                _form.richTextBoxDescription.Text = null;
                _form.pictureBoxPicture.Image = null;
                _form.dataGridViewElectricalEquipment.DataSource = null;

                _categories.Clear();
                _electricalEquipment.Clear();
                _charateristics.Clear();
                _goods.Clear();
                MessageBox.Show("В данной категории нет электрооборудования");
            }

            return check;
        }
    }
}
