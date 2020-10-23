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
    public partial class frmUpdateRecord : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        DBConnection dbcon = new DBConnection();
        public frmUpdateRecord()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.Mycon());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            cm = new SqlCommand("select * from tblCon",con);
            dr = cm.ExecuteReader();
            txtConID.Text = dr["con-id"].ToString();
            dr.Close();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
