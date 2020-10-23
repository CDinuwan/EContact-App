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
        SqlDataReader dr;
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
            comGender.ResetText();
            dataGridView1.Rows.Clear();
            txtSearch.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtConID.Text != String.Empty && txtAddress.Text != String.Empty && txtCon_no.Text != String.Empty && txtFN.Text != String.Empty)
                {
                    if (MessageBox.Show("Are you sure you want to add this record?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                }
                else 
                {
                    MessageBox.Show("Incorrect !","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
        }
        public void LoadRecord()
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            con.Open();
            dataGridView1.Rows.Clear();
            cm = new SqlCommand("select first_name,contact_no,address,gender from tblCon where con_id like '" + txtSearch.Text + "'", con);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr["first_name"].ToString(), dr["contact_no"].ToString(), dr["address"].ToString(), dr["gender"].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUpdateRecord frm = new frmUpdateRecord();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmSelectContactID frm = new frmSelectContactID();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }

    }
}
