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

namespace SQL
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public SqlConnection connect()
        {
            SqlConnection con = new SqlConnection();
            string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\SQL\SQL\Database1.mdf;Integrated Security=True;Connect Timeout=30;";
            con = new SqlConnection(strCon);

            con.Open();
            return con;
        }
        private void button11_Click_1(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            if (textBox13.Text == "123" && textBox12.Text == "000")
            {
                string strSQL = "select * from data where state=N'" + comboBox3.Text + "' ";

                SqlCommand cmd = new SqlCommand(strSQL, connect());
                SqlDataReader rd = cmd.ExecuteReader();

                label40.Text = "";

                while (rd.Read())
                {

                    label40.Text = rd.GetString(0);
                    checkedListBox1.Items.Add(label40.Text);
                }
                if (!rd.HasRows)
                {
                    MessageBox.Show("查無此人");
                }
            }

            else
            {
                MessageBox.Show("帳號密碼錯誤");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label39.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {

                if (checkedListBox1.GetItemChecked(i) == true)
                {
                    label39.Text = label39.Text + checkedListBox1.Items[i].ToString();
                }
            }

            String strSQL = "";
            if (comboBox3.Text == "待出貨")
            {
                strSQL = "update data set state=N'待收貨'where number='" + label39.Text + "'";
                MessageBox.Show("出貨成功");
            }
            if (comboBox3.Text == "待收貨")
            {
                strSQL = "update  data set state=N'訂單已完成'where number='" + label39.Text + "'";
                MessageBox.Show("訂單已完成");
            }

            SqlCommand cmd = new SqlCommand(strSQL, connect());
            SqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                cmd.Connection = connect();
                cmd.ExecuteNonQuery();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
