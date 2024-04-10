using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model_de_test_3
{
    public partial class AddEditForm : Form
    {   
        public Students Students {  get; set; }
        public AddEditForm()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(Students != null)
            {
                Students.Id = (int)numId.Value;
                Students.Name = tbName.Text;
               if(double.TryParse(tbGrade.Text, out double grade)){
                    Students.Grade = grade;
                }
            }
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            numId.Value = Students.Id;
            tbName.Text = Students.Name;
            tbGrade.Text = Students.Grade.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbGrade_Validating(object sender, CancelEventArgs e)
        {
            if (double.TryParse(tbGrade.Text, out double grade))
            {
                if (grade > 10) {
                    e.Cancel = true;
                    errorProvider1.SetError((Control)sender, "Invalid grade");
                }
            }
        }
    }
}
