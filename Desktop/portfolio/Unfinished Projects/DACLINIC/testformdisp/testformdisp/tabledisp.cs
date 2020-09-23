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

//

namespace testformdisp
{
    public partial class tabledisp : Form
    {
        public tabledisp()
        {
            InitializeComponent();
        }

        //CHANGE ACCOUNT
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA; Data Source=XE;User ID=DACLINIC;Password=da;Unicode=True");

        //BUTTONS 1 -8  ARE FOR TESTING
        //BUTTON 9 IS FOR LOG OUT
        //FINAL REPORTS ARE BUTTONS 10-13
        private void button1_Click(object sender, EventArgs e)
        {
            //patient
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from patient order by patient_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //doctor
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select doctor_id, doc_fname, doc_lname, doc_mi, doc_sfx, lic_no, ptr_no from doctor order by doctor_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //appointment
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from appointment order by appointment_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //operations
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from operation order by operation_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //operatiosn perfromed
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from operation_done order by appointment_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //accounts payable
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from accounts_payable order by receipt_number", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //prescription
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from prescription order by prescription_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //prescription gd
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("Select * from prescription_gd order by prescription_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //LOG OUT
            this.Hide();
            login rst = new login();
            rst.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //APPOINTMENTS JOIN
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT appointment.appointment_id, patient.lname || ', ' || patient.fname AS NAME, appointment.app_date_time, appointment.complain, appointment.diagnosis FROM patient RIGHT OUTER JOIN appointment ON patient.patient_id = appointment.patient_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //OPERATIONS JOIN
            conn.Open();
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT P.PATIENT_ID, P.FNAME ||' '||  P.LNAME AS NAME, A.APPOINTMENT_ID, A.APP_DATE_TIME, OP.OPERATION_ID, OP.OPERATION_TYPE FROM PATIENT P LEFT JOIN APPOINTMENT A ON P.PATIENT_ID = A.PATIENT_ID JOIN OPERATION_DONE OD ON A.APPOINTMENT_ID = OD.APPOINTMENT_ID LEFT JOIN OPERATION OP ON OD.OPERATION_ID = OP.OPERATION_ID", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //ACCOUNTS PAYABLE JOIN

            //REMOVED
            conn.Open();
            //paste new QUERY
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT p.patient_id, p.lname ||', '|| p.fname AS NAME, a.receipt_number, a.paid_date, paid_amount, balance FROM patient p RIGHT JOIN accounts_payable a ON p.patient_id = a.patient_id", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //PRESCRIPTION JOIN
            conn.Open();
            //paste new QUERY
            OleDbDataAdapter oda = new OleDbDataAdapter("SELECT FNAME || ' ' || LNAME AS NAME, APPOINTMENT_ID, APP_DATE_TIME, PRESCRIPTION_ID, GENERIC_MED_NAME, DOSAGE FROM PATIENT LEFT JOIN APPOINTMENT ON APPOINTMENT.PATIENT_ID = PATIENT.PATIENT_ID JOIN PRESCRIPTION ON PRESCRIPTION.PATIENT_ID = PATIENT.PATIENT_ID JOIN PRESCRIPTION_GD ON PRESCRIPTION_GD.PRESCRIPTION_ID = PRESCRIPTION.PRESCRIPTION_ID", conn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        //DML BUTTONS

        private void button6_Click_1(object sender, EventArgs e)
        {
            //PATIENT DML
            ca_patient c_act_pat = new ca_patient();
            c_act_pat.Show();

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            //APPOINTMENT DML
            ca_appointment c_act_app = new ca_appointment();
            c_act_app.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //OPERATIONS DML
            ca_op_perf c_act_op = new ca_op_perf();
            c_act_op.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //MEDICINE DML
        }
    }
}
