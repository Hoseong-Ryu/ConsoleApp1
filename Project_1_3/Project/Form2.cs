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
    public partial class Form2 : Form
    {
        private string constr = "SERVER = 127.0.0.1,1433; DATABASE = StudyCafe;" +
            "UID = as; PASSWORD = 1234";
        public Form2()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constr);
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from Customer where name='" + textBox1.Text + "' and phone='" + textBox2.Text + "';", conn);
            DataTable dataTable = new DataTable();

            sda.Fill(dataTable);

            if (dataTable.Rows[0][0].ToString() == "1")
            {
                //this.Hide();
                MainForm mainForm1 = new MainForm(this);
                mainForm1.ShowDialog();

                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (textBox1.Text.Equals("admin"))
            {
                //this.Close();

                Form3 form3 = new Form3();
                form3.ShowDialog();
            }
            else
            {
                MessageBox.Show("아이디와 비밀번호를 확인해주세요");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        
    }
}
