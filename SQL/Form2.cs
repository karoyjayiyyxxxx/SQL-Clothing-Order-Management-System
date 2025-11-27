using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                label23.Text = label23.Text + "星期三";
                MessageBox.Show("週三免運費");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label23.Text = DateTime.Now.ToString();
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                label23.Text = label23.Text + "星期一";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
            {
                label23.Text = label23.Text + "星期二";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                label23.Text = label23.Text + "星期三";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
            {
                label23.Text = label23.Text + "星期四";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                label23.Text = label23.Text + "星期五";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                label23.Text = label23.Text + "星期六";
            }
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                label23.Text = label23.Text + "星期日";
            }
        }
        public SqlConnection connect()
        {
            SqlConnection con = new SqlConnection();
            string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\SQL\SQL\Database1.mdf;Integrated Security=True;Connect Timeout=30;";
            con = new SqlConnection(strCon);

            con.Open();
            return con;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSQL = "select * from Member where Id='" + textBox1.Text + "'and password='" + textBox2.Text + "'";

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();

            label3.Text = "";

            while (rd.Read())
            {

                label3.Text = label3.Text + "帳號: " + rd.GetString(0) + "      密碼: " + rd.GetString(1) + "      姓名: " + rd.GetString(2);

            }
            if (!rd.HasRows)
            {
                MessageBox.Show("查無此人");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String strSQL = "insert Member(id,password,name) values (N'" + textBox1.Text + "',N'" + textBox2.Text + "',N'" + textBox3.Text + "')";

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            MessageBox.Show("新增成功");
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                cmd.Connection = connect();
                cmd.ExecuteNonQuery();
                MessageBox.Show("新增成功");
                label3.Text = label3.Text + "帳號: " + rd.GetString(0) + "      密碼: " + rd.GetString(1) + "      姓名: " + rd.GetString(2);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String strSQL = "delete from   Member where Id='" + textBox1.Text + "'";

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();
            MessageBox.Show("刪除成功");

            while (rd.Read())
            {
                cmd.Connection = connect();
                cmd.ExecuteNonQuery();
                label3.Text = label3.Text + "帳號: " + rd.GetString(0) + "      密碼: " + rd.GetString(1) + "      姓名: " + rd.GetString(2);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String strSQL = "update  Member set password='" + textBox2.Text + "',name=N'" + textBox3.Text + "'where id='" + textBox1.Text + "'";

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();
            MessageBox.Show("更新成功");


            while (rd.Read())
            {
                cmd.Connection = connect();
                cmd.ExecuteNonQuery();
                label3.Text = label3.Text + "帳號: " + rd.GetString(0) + "      密碼: " + rd.GetString(1) + "      姓名: " + rd.GetString(2);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string strSQL = "select * from  Member where Id='" + textBox4.Text + "'and password='" + textBox5.Text + "'";

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();

            label3.Text = "";

            while (rd.Read())
            {
                MessageBox.Show("登入成功");
                label35.Text = "您好  " + rd.GetString(2);
                label36.Text = rd.GetString(2);
                label3.Text = label3.Text + rd.GetString(0) + rd.GetString(1) + rd.GetString(2);
                panel1.Enabled = true;
            }
            if (!rd.HasRows)
            {
                MessageBox.Show("查無此人");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button7.ForeColor = Color.Black;
            button6.ForeColor = Color.Red;

            string strSQL = "select * from goods where Id=N'A款'";

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();

            label3.Text = "";

            while (rd.Read())
            {
                label12.Text = rd.GetString(0);
                label14.Text = rd.GetString(1);
                label15.Text = rd.GetString(2);
                label21.Text = rd.GetString(3);
            }
            if (!rd.HasRows)
            {
                MessageBox.Show("查無此人");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.ForeColor = Color.Red;
            button6.ForeColor = Color.Black;

            string strSQL = "select * from goods where Id=N'B款'";

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();

            label3.Text = "";

            while (rd.Read())
            {
                label12.Text = rd.GetString(0);
                label14.Text = rd.GetString(1);
                label15.Text = rd.GetString(2);
                label21.Text = rd.GetString(3);
            }
            if (!rd.HasRows)
            {
                MessageBox.Show("查無此人");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("請輸入數值", "", MessageBoxButtons.OKCancel);
            }
            panel2.Enabled = true;
            int money = Convert.ToInt32(label14.Text) * Convert.ToInt32(textBox6.Text);
            label32.Text = "$" + Convert.ToString(money);
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                label33.Text = "$0(週三免運)";
                int b = money;
                label34.Text = "$" + (b).ToString();
            }
            else
            {
                label33.Text = "$60";
                int b = money + 60;
                label34.Text = "$" + (b).ToString();
            }
           
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string[] code = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            label24.Text = "";
           Random rd1 = new Random();
            int i;
            for (int a = 0; a < 9; a++)
            {
                i = rd1.Next(0, 35);

                label24.Text = label24.Text + code[i];

                for (int j = 0; j < i; j++)
                {
                    while (code[i] == code[j])
                    {
                        j = 0;
                        code[j] = rd1.Next(0, 35).ToString();
                        label24.Text = label24.Text + code[i];

                    }

                }

            }

            MessageBox.Show("下單成功", "", MessageBoxButtons.OKCancel);
            int s = Convert.ToInt32(label14.Text) * Convert.ToInt32(textBox6.Text);
            label32.Text = "$" + Convert.ToString(s);
            label33.Text = "$60";
            int b = s + 60;
            label34.Text = (b).ToString();

            try
            {
                String strSQL = "update goods set Inventory='" + (Convert.ToInt32(label15.Text) - int.Parse(textBox6.Text)).ToString() + "',Sales='" + (Convert.ToInt32(label21.Text) + int.Parse(textBox6.Text)).ToString() + "'where Id=N'" + label12.Text + "'";
                SqlCommand cmd = new SqlCommand(strSQL, connect());
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    cmd.Connection = connect();
                    cmd.ExecuteNonQuery();
                }

            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            try
            {

                String strSQL = "insert data (number,Id,name,goods,quantity,total,transport,retail,payment,state) values (N'" + label24.Text + "',N'" + textBox4.Text + "',N'" + label36.Text + "',N'" + label12.Text + "',N'" + textBox6.Text + "',N'" + label34.Text + "',N'" + comboBox1.Text + "',N'" + textBox10.Text + "',N'" + comboBox2.Text + "',N'待出貨')";

                SqlCommand cmd = new SqlCommand(strSQL, connect());
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    cmd.Connection = connect();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label20.Text = "";

            string strSQL = "select * from  data where Id='" + textBox8.Text + "'and name=N'" + textBox7.Text + "'";
            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                label22.Text = "帳號       　 　姓名        商品       數量     總額       運送方式         門市          付款方式               狀態";
                label20.Text = label20.Text + rd.GetString(0) +"　　"+rd.GetString(2) + "　　" + rd.GetString(3) + "　　" + rd.GetString(4) + "　　" + rd.GetString(5) + "　　" + rd.GetString(6) + "　　" + rd.GetString(7) + "　　" + rd.GetString(8) + "　　" + rd.GetString(9) + "\n\n";
              
            }
            if (!rd.HasRows)
            {
                MessageBox.Show("查無此訂單");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }

       
    }
}
