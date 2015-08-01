using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;

namespace Proiect_Final
{
    public partial class Te_crezi_IT_ist : Form
    {
        OleDbConnection con = new OleDbConnection();
        OleDbCommand com = new OleDbCommand();
        string score, user, pass,sub;
        public Te_crezi_IT_ist()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            label3.Text = "Te crezi IT-ist?";
            label3.ForeColor = Color.White;
            label3.Visible = true;
            panel1.BackColor = Color.DimGray;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            label2.Visible = false;
            label8.Visible = false;
            textBox1.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
           
        }

        private void Te_crezi_IT_ist_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\book\Util\log.txt");

            string a = sr.ReadLine();
            sub = sr.ReadLine();
            label6.Text = a;
            label7.Text = sub;
            sr.Close();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Infoeducatie.accdb;
Persist Security Info=False;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button3.Visible = false;
            label2.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            label3.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\book\Util\level.txt");
            sw.WriteLine("1");
            sw.Close();
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\book\Util\level.txt");
            sw.WriteLine("2");
            sw.Close();
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(@"C:\book\Util\level.txt");
            sw.WriteLine("3");
            sw.Close();
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = false;
            label3.Visible = false;
            label8.Visible = true;
            textBox1.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                
                com.Connection = con;
                com.CommandText = @"SELECT * FROM Conturi WHERE Username='" + textBox1.Text + "'";
                com.CommandType = System.Data.CommandType.Text;

                OleDbDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    user = reader.GetString(1);
                    pass = reader.GetString(2);
                    score = reader["score"].ToString();
                    //MessageBox.Show("'"+score+"'");

                }
                int a;
                a = Convert.ToInt32(score);
                int b = Convert.ToInt32(sub);
                int c = b - a;
                if (c > 0)
                {
                    MessageBox.Show("Bravoo , ai un scor mai mare cu " + c + " decat jucatorul ales");
                }
                if (c == 0)
                {
                    MessageBox.Show("Esti la egalitate cu jucatorul ales");
                }
                if (c < 0)
                {
                    c = -1 * c;
                    MessageBox.Show("Jucatorul ales are un scor mai mare cu " + c + " decat tine");
                }
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Jucatorul nu a fost gasit ");
                con.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button2.Visible = true;
            label3.Visible = true;
            label8.Visible = false;
            textBox1.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
        }
    }
}
