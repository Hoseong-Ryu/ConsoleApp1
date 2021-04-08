
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
    public partial class MainForm : Form
    {
        Form2 form2;
        private string constr = "SERVER = 127.0.0.1,1433; DATABASE = StudyCafe;" +
            "UID = as; PASSWORD = 1234";
        String applyTime = "";

        System.Windows.Forms.Timer timer;
        TimeSpan countdownClock = TimeSpan.Zero;

        int hour, minute, second, changeHour;

        public MainForm(Form2 form)
        {
            InitializeComponent();
            form2 = form;
            button2.Visible = false;
            button3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            dataGridView1.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            
            reset();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;

            reset();
        }
        private void reset()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                string sql = "Select roomname 스터디룸, usepeople 사용인원, maxpeople 최대인원 from Room; ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Room");
            }
            dataGridView1.DataSource = ds.Tables[0];

            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select time from Customer Where phone = '" + form2.textBox2.Text + "';", conn);
                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);

                //label5.Text = dataTable.Rows[0][0].ToString()+"시간";
                if (dataTable.Rows[0][0].ToString() == "")
                    label5.Text = "0 시간";
                else
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = "select second from Customer where phone =" + form2.textBox2.Text;
                    int seconds = (int)command.ExecuteScalar();

                    AddTimeToClock(TimeSpan.FromSeconds(seconds));
                }

            }

            updateUsePeople();
            UpdateTable();

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
            groupBox3.Visible = true;
            groupBox1.Visible = true;
            dataGridView1.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            
        }

        private void btnCheck()
        {
            if (radioButton1.Checked)
            {
                //MessageBox.Show("선택됐습니다.");
                applyTime = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                //MessageBox.Show("선택됐습니다.");
                applyTime = radioButton2.Text;
            }

            else if (radioButton3.Checked)
            {
                //MessageBox.Show("선택됐습니다.");
                applyTime = radioButton3.Text;
            }

            else if (radioButton4.Checked)
            {
                //MessageBox.Show("선택됐습니다.");
                applyTime = radioButton4.Text;
            }

            else if (radioButton5.Checked)
            {
                //MessageBox.Show("선택됐습니다.");
                applyTime = radioButton5.Text;
            }
            else if (radioButton6.Checked)
            {
                //MessageBox.Show("선택됐습니다.");
                applyTime = radioButton6.Text;
            }

            else if (radioButton7.Checked)
            {
                MessageBox.Show("선택됐습니다.");
                applyTime = radioButton7.Text;
            }

            else if (radioButton9.Checked)
            {
                MessageBox.Show("선택됐습니다.");
                applyTime = radioButton9.Text;
            }

            else if (radioButton10.Checked)
            {
                MessageBox.Show("선택됐습니다.");
                applyTime = radioButton10.Text;
            }
            else
            {
                MessageBox.Show("시간을 선택하세요.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer.Stop();
            string str = label5.Text;
            string[] result = str.Split(new char[] { ':' });
            for(int i =0; i<result.Length; i++)
            {
                if (i == 0)
                {
                    hour = int.Parse(result[i]);
                    hour = 3600 * hour;
                }
                else if (i == 1)
                {
                    minute = int.Parse(result[i]);
                    minute = 60 * minute;
                }
                else if (i == 2)
                {
                    second = int.Parse(result[i]);
                }
            }
            using (SqlConnection conn = new SqlConnection(constr))
            {

                int totalSecond = hour + minute + second;

                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "Update Customer SET second = '"+totalSecond+"' Where phone = '" + form2.textBox2.Text + "';";
                command.ExecuteNonQuery();
                //AddTimeToClock(TimeSpan.FromHours(double.Parse(applyTime)));

                command.CommandText = "Update Customer set roomid = 0 Where phone = '" + form2.textBox2.Text + "';";
                command.ExecuteNonQuery();
                updateUsePeople();
                UpdateTable();
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            btnCheck();
            if(radioButton1.Checked|| radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked || radioButton7.Checked || radioButton9.Checked || radioButton10.Checked)
            {
                changeHour = 3600 * int.Parse(applyTime);
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "Update Customer  set roomid = 1,  second+= '" + changeHour + "', price+= (select price from Ticket where time = '" + applyTime + "')  Where phone = '" + form2.textBox2.Text + "';";
                    command.ExecuteNonQuery();
                    AddTimeToClock(TimeSpan.FromHours(double.Parse(applyTime)));
                    
                }
                //여기 기능 추가
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select usepeople, maxpeople from Room Where roomname = 'focus';", conn);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString().Equals(dataTable.Rows[0][1].ToString()))
                        MessageBox.Show("자리가 없습니다.");
                    else
                    {
                        //updateUsePeople();
                        btnCheck();
                        UpdateTable();
                        //Application.Restart();

                    }
                        
                }
                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            btnCheck();
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked || radioButton7.Checked || radioButton9.Checked || radioButton10.Checked)
            {
                changeHour = 3600 * int.Parse(applyTime);
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "Update Customer  set roomid = 2,  second+= '" + changeHour + "', price+= (select price from Ticket where time = '" + applyTime + "')  Where phone = '" + form2.textBox2.Text + "';";
                    command.ExecuteNonQuery();
                    AddTimeToClock(TimeSpan.FromHours(double.Parse(applyTime)));
                }

                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select usepeople, maxpeople from Room Where roomname = 'cafe';", conn);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString().Equals(dataTable.Rows[0][1].ToString()))
                        MessageBox.Show("자리가 없습니다.");
                    else
                    {
                        updateUsePeople();
                        btnCheck();
                        UpdateTable();
                        //Application.Restart();
                    }

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            btnCheck();
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked || radioButton4.Checked || radioButton5.Checked || radioButton6.Checked || radioButton7.Checked || radioButton9.Checked || radioButton10.Checked)
            {
                changeHour = 3600 * int.Parse(applyTime);
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = "Update Customer  set roomid = 3,  second+= '" + changeHour + "', price+= (select price from Ticket where time = '" + applyTime + "')  Where phone = '" + form2.textBox2.Text + "';";
                    command.ExecuteNonQuery();
                    AddTimeToClock(TimeSpan.FromHours(double.Parse(applyTime)));
                }
                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlDataAdapter sda = new SqlDataAdapter("Select usepeople, maxpeople from Room Where roomname = 'hive';", conn);
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString().Equals(dataTable.Rows[0][1].ToString()))
                        MessageBox.Show("자리가 없습니다.");
                    else
                    {
                        updateUsePeople();
                        btnCheck();
                        UpdateTable();
                        //Application.Restart();
                    }

                }
            }
        }
        private void updateUsePeople()
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "update Room set usepeople = (select COUNT(*) from Customer where roomid = 1 group by roomid)where roomid = 1; ";
                command.ExecuteNonQuery();
                command.CommandText = "update Room set usepeople = (select COUNT(*) from Customer where roomid = 2 group by roomid)where roomid = 2; ";
                command.ExecuteNonQuery();
                command.CommandText = "update Room set usepeople = (select COUNT(*) from Customer where roomid = 3 group by roomid)where roomid = 3; ";
                command.ExecuteNonQuery();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void OnTimeEvent(object sender, EventArgs e)
        {
            label5.Text = applyTime;

            countdownClock = countdownClock.Subtract(TimeSpan.FromMilliseconds(timer.Interval));
            if (countdownClock.TotalMilliseconds <= 0)
            {
                // Countdown clock has run out, so set it to zero 
                // (in case it's negative), and stop our timer
                countdownClock = TimeSpan.Zero;
                timer.Stop();
            }
            // Display the current time
            DisplayTime();
        }

        private void DisplayTime()
        {
            label5.Text = countdownClock.ToString();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = (int)TimeSpan.FromSeconds(1).TotalMilliseconds;
            timer.Tick += OnTimeEvent;
            DisplayTime();
        }

        private void AddTimeToClock(TimeSpan timeSpan)
        {
            // Add time to our clock
            countdownClock += timeSpan;
            // Display the new time
            DisplayTime();
            // Start the timer if it's stopped
            if (!timer.Enabled) timer.Start();
        }

        private void UpdateTable()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                string sql = "Select roomname 스터디룸, usepeople 사용인원, maxpeople 최대인원 from Room; ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(ds, "Room");
            }
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
