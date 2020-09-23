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
    public partial class patient_delete : Form
    {
        public patient_delete()
        {
            InitializeComponent();
        }

        private void patient_delete_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DELETE
            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = "DELETE FROM patient WHERE PATIENT_ID = '" + this.textBox1.Text + "'";

                OracleCommand cmd2 = new OracleCommand();
                cmd2.Connection = conn;
                cmd2.CommandText = "DELETE FROM appointment WHERE PATIENT_ID = '" + this.textBox1.Text + "'";

                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "DELETE FROM prescription WHERE PATIENT_ID = '" + this.textBox1.Text + "'";

                OracleCommand cmd4 = new OracleCommand();
                cmd4.Connection = conn;
                cmd4.CommandText = "DELETE FROM accounts_payable WHERE PATIENT_ID = '" + this.textBox1.Text + "'";

                //medicine and dosage
                OracleCommand med_del = new OracleCommand();
                med_del.Connection = conn;
                med_del.CommandText = "DELETE FROM PRESCRIPTION_GD WHERE PRESCRIPTION_ID IN (SELECT PR.PRESCRIPTION_ID FROM PRESCRIPTION_GD G LEFT OUTER JOIN PRESCRIPTION PR ON G.PRESCRIPTION_ID = PR.PRESCRIPTION_ID INNER JOIN PATIENT P ON PR.PATIENT_ID = P.PATIENT_ID WHERE P.PATIENT_ID =  '" + this.textBox1.Text + "')";

                //operations done
                OracleCommand op_del = new OracleCommand();
                op_del.Connection = conn;
                op_del.CommandText = "DELETE FROM OPERATION_DONE WHERE OPERATION_ID IN (SELECT OD.OPERATION_ID FROM OPERATION_DONE OD INNER JOIN APPOINTMENT A ON OD.APPOINTMENT_ID = A.APPOINTMENT_ID LEFT JOIN PATIENT P ON A.PATIENT_ID = P.PATIENT_ID WHERE PATIENT_ID = '" + this.textBox1.Text + "')";

                conn.Open();

                med_del.ExecuteNonQuery(); //medicine and dosage
                op_del.ExecuteNonQuery(); //operation done
                cmd4.ExecuteNonQuery(); //accounts payable
                cmd3.ExecuteNonQuery(); //prescription
                cmd2.ExecuteNonQuery(); //appointment
                cmd1.ExecuteNonQuery(); //patient
                           
   
                conn.Close();
                MessageBox.Show("Successfully deleted.");
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

        private void button2_Click(object sender, EventArgs e)
        {
            //check
            OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select patient_id, fname||' '||lname AS NAME from patient where patient_id = '" + this.textBox1.Text + "' ", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
