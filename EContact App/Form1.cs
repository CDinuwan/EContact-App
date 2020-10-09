using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EContact_App
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnection dbcon = new DBConnection(); 
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.Mycon());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void Clear()
        {
            txtFN.Clear();
            txtLN.Clear();
            txtCon_no.Clear();
            txtConID.Clear();
            txtAddress.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to add this record?","Save",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("INSERT INTO tblCon(con_id, first_name, last_name, contact_no, address, gender)values(@con_id, @first_name, @last_name, @contact_no, @address, @gender)", con);
                    cm.Parameters.AddWithValue("@con_id", txtConID.Text);
                    cm.Parameters.AddWithValue("@first_name", txtFN.Text);
                    cm.Parameters.AddWithValue("@last_name", txtLN.Text);
                    cm.Parameters.AddWithValue("@contact_no", txtCon_no.Text);
                    cm.Parameters.AddWithValue("@address", txtAddress.Text);
                    cm.Parameters.AddWithValue("@gender", comGender.Text);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your information are successfully saved");
                    Clear();
                }
            }catch(Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
