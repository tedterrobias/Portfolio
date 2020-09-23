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
    public partial class op_delete : Form
    {
        public op_delete()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");
        
        OracleConnection conn2 = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //check
            OleDbDataAdapter oda = new OleDbDataAdapter("Select a.appointment_id, p.fname||' '|| p.lname AS NAME, operation_ID, operation_type from appointment a left outer join patient p on a.patient_id = p.patient_id right outer join operation_done od on a.appointment_id = od.appointment_id left outer join operation o on od.operation_id = o.operation_id where a.appointment_id = '" + this.textBox1.Text + "' ", conn);
            conn.Open();
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check
            OleDbDataAdapter oda = new OleDbDataAdapter("Select od.appointment_id, od.operation_id, o.operation_type from operation_done od left outer join operation o on od.operation_id = o.operation_id where od.operation_id = '" + this.textBox2.Text + "'", conn);
            conn.Open();
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand opd_del = new OracleCommand();
                opd_del.Connection = conn2;
                opd_del.CommandText = "DELETE FROM operation_done WHERE appointment_ID = '" + this.textBox1.Text + "' AND operation_id ='" + this.textBox2.Text + "' ";

                conn2.Open();
                opd_del.ExecuteNonQuery(); //operation done
                conn.Close();
                MessageBox.Show("Successfully deleted.");
                this.Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
    }
}
