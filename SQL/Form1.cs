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
using System.Data.SqlClient;
using System.Resources;
using System.Reflection.Emit;

namespace SQL
{
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2();
            form2.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form3 = new Form3();
            form3.Show();
            this.Hide();
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
