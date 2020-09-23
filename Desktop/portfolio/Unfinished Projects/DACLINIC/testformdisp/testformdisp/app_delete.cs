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
    public partial class app_delete : Form
    {
        public app_delete()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete

            try
            {
                OracleConnection conn = new OracleConnection("DATA SOURCE=SERVER14:1521/XE;PERSIST SECURITY INFO=True;USER ID=DACLINIC; PASSWORD=da");

                OracleCommand main_del = new OracleCommand();
                main_del.Connection = conn;
                main_del.CommandText = "DELETE FROM appointment WHERE appointment_ID = '" + this.textBox1.Text + "'";

                //operation done
                OracleCommand opd_del = new OracleCommand();
                opd_del.Connection = conn;
                opd_del.CommandText = "DELETE FROM operation_done WHERE appointment_ID = '" + this.textBox1.Text + "'";

                OracleCommand prsc_del = new OracleCommand();
                prsc_del.Connection = conn;
                prsc_del.CommandText = "DELETE FROM prescription WHERE appointment_ID = '" + this.textBox1.Text + "'";

                //medicine and dosage
                OracleCommand med_del = new OracleCommand();
                med_del.Connection = conn;
                med_del.CommandText = "DELETE FROM prescription_gd WHERE PRESCRIPTION_ID IN (SELECT PR.PRESCRIPTION_ID FROM PRESCRIPTION_GD G LEFT OUTER JOIN PRESCRIPTION PR ON G.PRESCRIPTION_ID = PR.PRESCRIPTION_ID WHERE PR.APPOINTMENT_ID = '" + this.textBox1.Text + "')";

                //accounts payable
               OracleCommand cmd4 = new OracleCommand();
               cmd4.Connection = conn;
               cmd4.CommandText = "DELETE FROM accounts_payable WHERE APPOINTMENT_ID = '" + this.textBox1.Text + "'";

                //operations done


                conn.Open();

                med_del.ExecuteNonQuery(); //medicine and dosage
                opd_del.ExecuteNonQuery(); //operation done
                cmd4.ExecuteNonQuery(); //accounts payable
                prsc_del.ExecuteNonQuery(); //prescription
                main_del.ExecuteNonQuery(); //appointment



                conn.Close();
                MessageBox.Show("Successfully deleted.");
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //check
            OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select a.appointment_id, p.fname||' '|| p.lname AS NAME from appointment a left outer join patient p on a.patient_id = p.patient_id where a.appointment_id = '" + this.textBox1.Text + "' ", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
