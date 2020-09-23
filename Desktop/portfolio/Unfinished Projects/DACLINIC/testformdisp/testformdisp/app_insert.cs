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
    public partial class app_insert : Form
    {
        public app_insert()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //COMPLAIN
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //INSERT
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into appointment (appointment_id, app_date_time, patient_id, doctor_id, complain, diagnosis) values (appointment_seq.nextval, sysdate, '" + this.textBox6.Text+"', '"+ this.textBox5.Text +"', '" + this.textBox1.Text + "', '" + this.textBox2.Text + "')";
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully inserted.");
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //DIAGNOSIS
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            //patient_id
        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            //doctor_id
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //patient id disp
            //patient
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select patient_id, lname ||', '|| fname AS NAME from patient where patient_id = '" +this.textBox6.Text+ "' ", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //doc id disp
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select doctor_id, doc_fname ||' '||doc_lname ||' '|| doc_sfx  AS NAME from doctor where doctor_id = '" + this.textBox5.Text + "' ", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView2.DataSource = dt;
            conn.Close();
        }

        private void app_insert_Load(object sender, EventArgs e)
        {

        }
    }
}
