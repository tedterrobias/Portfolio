using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data.OleDb;

namespace testformdisp
{
    public partial class op_search : Form
    {
        public op_search()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //search
            OleDbDataAdapter oda = new OleDbDataAdapter("Select a.appointment_id, p.fname||' '|| p.lname AS NAME, operation_ID, operation_type from appointment a left outer join patient p on a.patient_id = p.patient_id right outer join operation_done od on a.appointment_id = od.appointment_id left outer join operation o on od.operation_id = o.operation_id where od.appointment_id = '" + this.textBox1.Text + "' and od.operation_id = '" + this.textBox2.Text + "'", conn);
            conn.Open();
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
