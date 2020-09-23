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
    public partial class patient_update : Form
    {
        public patient_update()
        {
            InitializeComponent();
        }

        OleDbConnection conn1 = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");
        OracleConnection conn2 = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check
            conn1.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select patient_id, lname ||', '|| fname AS NAME from patient where patient_id = '" + this.textBox11.Text + "' ", conn1);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn1.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            conn2.Open();
            try
            {
                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn2;
                cmd.CommandText = "UPDATE patient set patient_id = '" + this.textBox1.Text + "', fname = '" + this.textBox2.Text + "', lname = '" + this.textBox3.Text + "', MI = '" + this.textBox4.Text + "', age = '" + this.textBox5.Text + "', gender = '" + this.textBox6.Text + "', address = '" + this.textBox7.Text + "', telephone = '" + this.textBox8.Text + "', occupation = '" + this.textBox9.Text + "', status = '" + this.textBox10.Text + "' WHERE patient_id = '" + this.textBox11.Text + "' ";

                
                cmd.ExecuteNonQuery();
                conn2.Close();
                MessageBox.Show("Successfully updated.");
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
