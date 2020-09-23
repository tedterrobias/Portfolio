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
    public partial class app_update : Form
    {

        OleDbConnection conn1 = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");
        OracleConnection conn2 = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");
        public app_update()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check app id
            conn1.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select a.appointment_id, fname ||' '|| lname AS NAME from appointment a left outer join patient p on a.patient_id = p.patient_id where a.appointment_id = '" + this.textBox6.Text + "' ", conn1);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //check patient id
            conn1.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select patient_id, fname ||' '|| lname AS NAME from patient where patient_id = '" + this.textBox4.Text + "' ", conn1);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView3.DataSource = dt;
            conn1.Close();
        }



        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //app id text box
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //patient id textbox
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //doc id textbox
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Doc ID
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //APP ID
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //PATIENT ID
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //complain
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //diagnosis 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update
            
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn2;
                cmd.CommandText = "UPDATE appointment set appointment_id = '" + this.textBox5.Text + "', patient_id = '" + this.textBox4.Text + "',  doctor_id = '" + this.textBox3.Text + "', complain = '" + this.textBox1.Text + "', diagnosis = '" + this.textBox2.Text + "' WHERE appointment_id = '" + this.textBox6.Text + "'";

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

        private void app_update_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //patient_id
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //patient


        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            //new appointment id
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //doctor view
            //check doctor id
            conn1.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("select doctor_id, doc_fname ||' '|| doc_lname ||' '|| doc_sfx AS DOC_NAME from doctor where doctor_id = '" + this.textBox3.Text + "' ", conn1);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn1.Close();
        }
    }
}
