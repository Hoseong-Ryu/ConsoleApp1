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
    public partial class Form1 : Form
    {
        string hwpw = "";

        private SqlConnection sqlconn = null;

        private string constr = "SERVER = 127.0.0.1,1433; DATABASE = StudyCafe;" +
            "UID = as; PASSWORD = 1234";

        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string hwid = textBox1.Text;
            this.hwpw = textBox2.Text;

            sqlconn = new SqlConnection(constr);
            sqlconn.Open();

            using (SqlConnection conn = new SqlConnection(constr))
            {
                if (hwid == null || hwpw == null)
                {
                    MessageBox.Show("다시 확인해주세요");
                }
                else {
                    if (hwpw.Length == 11)
                    {
                        conn.Open();

                            SqlCommand command = new SqlCommand();

                            command.Connection = conn;
                            command.CommandText = "INSERT INTO Customer(custid,name, phone,time,price,roomid, second) VALUES((SELECT ISNULL(MAX(custid) + 1, 1) FROM Customer),'" + hwid + "','" + hwpw + "', 0, 0,0,600);";
                            command.ExecuteNonQuery();

                            MessageBox.Show("회원가입 성공");
                            this.Close();
                    }
                    else
                        MessageBox.Show("회원가입 실패");
                }
            }
            /*using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Update Customer second = 0 where phone = '"+ textBox2.Text +"';";
                command.ExecuteNonQuery();

            }*/
        }
    }
}
