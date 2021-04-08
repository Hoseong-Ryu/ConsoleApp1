using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form3 : Form
    {
        private string constr = "SERVER = 127.0.0.1,1433; DATABASE = StudyCafe;" +
            "UID = as; PASSWORD = 1234";
        public Form3()
        {
            InitializeComponent();
            button2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                string sql = "SELECT c.name, r.roomname 스터디룸, c.time, c.price From Customer c, Room r where r.roomid = c.roomid";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Room");
            }
            dataGridView1.DataSource = ds.Tables[0];
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                string sql = "Select roomid 스터디룸id, Count(*) 인원수 from Customer group by roomid; ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Room");
            }
            dataGridView1.DataSource = ds.Tables[0];
            button2.Visible = true;
        }
    }
}