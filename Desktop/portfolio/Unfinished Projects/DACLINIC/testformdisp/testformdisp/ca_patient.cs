using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testformdisp
{
    public partial class ca_patient : Form
    {
        public ca_patient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            this.Hide();
            patient_insert p_insert = new patient_insert();
            p_insert.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            this.Hide();
            patient_delete p_delete = new patient_delete();
            p_delete.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            this.Hide();
            patient_update p_update = new patient_update();
            p_update.Show();
        }
    }
}
