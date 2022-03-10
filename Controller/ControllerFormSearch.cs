using Database_of_automation_elements.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_of_automation_elements.Controller
{
    class ControllerFormSearch
    {
        private FromSearch _form;

        public ControllerFormSearch(FromSearch sender)
        {
            _form = sender;
        }

        public string Search()
        {
            string nameEquiment = string.Empty;
            if (_form.textBox1.Text.Trim() !=string.Empty)
            {
                nameEquiment = _form.textBox1.Text;
                _form.Close();
                return nameEquiment;
            }
            else
            {
                MessageBox.Show("Ведите поисковых запрос");
                return null;
            }

        }
    }
}
