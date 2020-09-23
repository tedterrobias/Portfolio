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
    public partial class ca_op_perf : Form
    {
        public ca_op_perf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            op_insert op_ins = new op_insert();
            this.Hide();
            op_ins.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete
            op_delete op_del = new op_delete();
            this.Hide();
            op_del.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            op_update op_upd = new op_update();
            this.Hide();
            op_upd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //search
            op_search op_s = new op_search();
            this.Hide();
            op_s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //view
            op_view op_view = new op_view();
            this.Hide();
            op_view.Show();
        }
    }
}
