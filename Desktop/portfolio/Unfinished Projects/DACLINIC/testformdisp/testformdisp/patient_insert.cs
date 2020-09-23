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

namespace testformdisp
{
    public partial class patient_insert : Form
    {
        public patient_insert()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //INSERT
            //CHANGE TO SEQUENCE PRIMARY KEYS
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into patient (patient_id, fname, lname, MI, age, gender, address, telephone, occupation, status) values (patient_seq.nextval,'" + this.textBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + this.textBox5.Text + "','" + this.textBox6.Text + "','" + this.textBox7.Text + "','" + this.textBox8.Text + "','" + this.textBox9.Text + "','" + this.textBox10.Text + "')";

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //patient id

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //fname
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //lname
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //mi
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //age
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //gender
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //address
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //telephone
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //occupation
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //status
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

       
    }
}
