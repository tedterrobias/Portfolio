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
    public partial class op_update : Form
    {
        public op_update()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");

        OracleConnection conn2 = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //appointment id
            OleDbDataAdapter oda = new OleDbDataAdapter("Select a.appointment_id, p.fname||' '|| p.lname AS NAME, operation_ID, operation_type from appointment a left outer join patient p on a.patient_id = p.patient_id right outer join operation_done od on a.appointment_id = od.appointment_id left outer join operation o on od.operation_id = o.operation_id where a.appointment_id = '" + this.textBox4.Text + "' ", conn);
            conn.Open();
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //operation id
            OleDbDataAdapter oda = new OleDbDataAdapter("Select od.appointment_id, od.operation_id, o.operation_type from operation_done od left outer join operation o on od.operation_id = o.operation_id where od.operation_id = '" + this.textBox3.Text + "'", conn);
            conn.Open();
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn2;
                cmd.CommandText = "UPDATE operation_done set appointment_id = '" + this.textBox1.Text + "', operation_id = '" + this.textBox2.Text + "' WHERE appointment_id = '" + this.textBox4.Text + "' AND operation_id = '" + this.textBox3.Text + "'";

                conn2.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully updated.");
                conn2.Close();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //app
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //op
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //CHECK NEW APP
            OleDbDataAdapter oda = new OleDbDataAdapter("Select a.appointment_id, p.fname||' '|| p.lname AS NAME, operation_ID, operation_type from appointment a left outer join patient p on a.patient_id = p.patient_id right outer join operation_done od on a.appointment_id = od.appointment_id left outer join operation o on od.operation_id = o.operation_id where a.appointment_id = '" + this.textBox1.Text + "' ", conn);
            conn.Open();
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CHECK NEW OP
            OleDbDataAdapter oda = new OleDbDataAdapter("Select operation_id, operation_type from operation where operation_id = '" + this.textBox2.Text + "'", conn);
            conn.Open();
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView4.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //NEW APP
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //NEW OP
        }

        private void op_update_Load(object sender, EventArgs e)
        {

        }
    }
}
