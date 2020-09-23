using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace testformdisp
{
    public partial class op_insert : Form
    {
        public op_insert()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check app
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("select a.appointment_id, a.app_date_time, a.patient_id, fname || ' ' || lname from appointment a left outer join patient p on a.patient_id = p.patient_id where appointment_id = '" + this.textBox6.Text + "' ", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //check op
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from operation where operation_id = '" + this.textBox5.Text + "' ", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //insert
            try
            {
                OracleConnection conn1 = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn1;
                cmd.CommandText = "insert into operation_done (appointment_id, operation_id) values ('" + this.textBox6.Text + "', '" + this.textBox5.Text + "')";
                conn1.Open();
                cmd.ExecuteNonQuery();
                conn1.Close();
                MessageBox.Show("Successfully inserted.");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
