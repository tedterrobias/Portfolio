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
    public partial class ca_appointment : Form
    {
        public ca_appointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            this.Hide();
            app_insert app_insert = new app_insert();
            app_insert.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            this.Hide();
            app_delete app_del = new app_delete();
            app_del.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
          this.Hide();
          app_update app_up = new app_update();
          app_up.Show();
        }
    }
}
