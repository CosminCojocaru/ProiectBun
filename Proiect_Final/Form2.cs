using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_Final
{
    public partial class Form2 : Form
    {
        OleDbConnection con = new OleDbConnection();
        OleDbCommand com = new OleDbCommand();
        Form3 f3 = new Form3();
        string ras_1,user,sco;
        int a;
        System.IO.StreamReader sw1 = new System.IO.StreamReader(@"C:\book\Util\sco.txt");
       
        public Form2()
        {
            InitializeComponent();
            label1.Visible = false;
            button6.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            textBox1.Visible = false;
            button7.Visible = false;
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Infoeducatie.accdb;
Persist Security Info=False;";
            //con.Open();
            com.Connection = con;
            System.IO.StreamReader sr = new System.IO.StreamReader(@"C:\book\Util\level.txt");
            string s = sr.ReadLine();
            if(s=="2")
            {
                con.Open();
                com.CommandText = @"SELECT  * FROM Mediu ORDER BY Rnd(-10000000*TimeValue(Now())*[id])";
                com.CommandType = System.Data.CommandType.Text;

                OleDbDataReader reader = com.ExecuteReader();
                button4.Visible = true;
                button3.Visible = true;
                button2.Visible = true;
                button1.Visible = true;
                label1.Visible = true;
                while (reader.Read() )
                {
                    ras_1 = reader.GetString(6);

                    label1.Text = reader.GetString(1);
                    button1.Text = reader.GetString(2);
                    button2.Text = reader.GetString(3);
                    button3.Text = reader.GetString(4);
                    button4.Text = reader.GetString(5);

                }
                
                sco = sw1.ReadLine();
                con.Close();
            }
            if(s=="1")
            {
                con.Open();
                com.CommandText = @"SELECT  * FROM Usor ORDER BY Rnd(-10000000*TimeValue(Now())*[id])";
                com.CommandType = System.Data.CommandType.Text;

                OleDbDataReader reader = com.ExecuteReader();
                label1.Visible = true;
                button6.Visible = true;
                button5.Visible = true;
                while (reader.Read())
                {
                    label1.Text = reader.GetString(1);
                    ras_1 = reader.GetString(2);
                }
                button5.Text = "DA";
                button6.Text = "NU";
                user = sw1.ReadLine();
                sco = sw1.ReadLine();
                con.Close();

            }
            if(s=="3")
            {
                con.Open();
                com.CommandText = @"SELECT  * FROM Greu ORDER BY Rnd(-10000000*TimeValue(Now())*[id])";
                com.CommandType = System.Data.CommandType.Text;

                OleDbDataReader reader = com.ExecuteReader();
                label1.Visible = true;
               // label2.Visible = true;
                textBox1.Visible = true;
                button7.Visible = true;
                while (reader.Read())
                {
                    label1.Text = reader.GetString(1);
                    ras_1 = reader.GetString(2);
                }
                
                user = sw1.ReadLine();
                sco = sw1.ReadLine();
                con.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(sco);
            if (button3.Text == ras_1)
            {
                Thread.Sleep(300);
                MessageBox.Show("Bravo , raspunsul tau e corect si au fost adaugate 10 puncte in contul tau .", "Corect");
            a += 10;
            }
            else
            {
                Thread.Sleep(300);
                MessageBox.Show("Raspunsul tau e gresit . Incearca data viitoare , dar deocamdata au fost retrase 5 puncte din contul tau.", "Gresit");
                a -= 5;
            }
            con.Open();
            
            this.Hide();
            f3.Show();
            com.CommandText  = "UPDATE Conturi SET Score="+a+" WHERE Username='"+user+"'";
            com.CommandType.ToString();
            //com.ExecuteNonQuery();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(sco);
            if (button1.Text == ras_1)
            {
                //Thread.Sleep(300);
                MessageBox.Show("Bravo , raspunsul tau e corect si au fost adaugate 10 puncte in contul tau .", "Corect");
                a += 10;
            }
            else
            {
                //Thread.Sleep(300);
                MessageBox.Show("Raspunsul tau e gresit . Incearca data viitoare , dar deocamdata au fost retrase 5 puncte din contul tau.", "Gresit");
                a -= 5;
            }
            con.Open();
            com.CommandText = "UPDATE Conturi SET Score=" + a + " WHERE Username='" + user + "'";
            this.Hide();
            f3.Show();
            com.CommandType.ToString();
           // com.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(sco);
            if (button2.Text == ras_1)
            {
                //Thread.Sleep(300);
                MessageBox.Show("Bravo , raspunsul tau e corect si au fost adaugate 10 puncte in contul tau .", "Corect");
                a += 10;
            }
            else
            {
                //Thread.Sleep(300);
                MessageBox.Show("Raspunsul tau e gresit . Incearca data viitoare , dar deocamdata au fost retrase 5 puncte din contul tau.", "Gresit");
                a -= 5;
            }
            con.Open();
            com.CommandText = "UPDATE Conturi SET Score=" + a + " WHERE Username='" + user + "'";
            this.Hide();
            f3.Show();
            com.CommandType.ToString();
           // com.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(sco);
            if (button4.Text == ras_1)
            {
                Thread.Sleep(300);
                MessageBox.Show("Bravo , raspunsul tau e corect si au fost adaugate 10 puncte in contul tau .", "Corect");
                a += 10;
            }
            else
            {
                Thread.Sleep(300);
                MessageBox.Show("Raspunsul tau e gresit . Incearca data viitoare , dar deocamdata au fost retrase 5 puncte din contul tau.", "Gresit");
                a -= 5;
            }
            con.Open();
            com.CommandText = "UPDATE Conturi SET Score=" + a + " WHERE Username='" + user + "'";
            this.Hide();
            f3.Show();
            com.CommandType.ToString();
           // com.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             a = Convert.ToInt32(sco);
            if (button5.Text == ras_1)
            {
                Thread.Sleep(300);
                MessageBox.Show("Bravo , raspunsul tau e corect si au fost adaugate 5 puncte in contul tau .", "Corect");
                a += 5;
            }
            else
            {
                Thread.Sleep(300);
                MessageBox.Show("Raspunsul tau e gresit . Incearca data viitoare , dar deocamdata au fost retrase 2 puncte din contul tau.", "Gresit");
                a -= 2;
            }
            con.Open();
            com.CommandText = "UPDATE Conturi SET Score=" + a + " WHERE Username='" + user + "'";
            this.Hide();
            f3.Show();
            com.CommandType.ToString();
            //com.ExecuteNonQuery();
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(sco);
            if (button6.Text == ras_1)
            {
                Thread.Sleep(300);
                MessageBox.Show("Bravo , raspunsul tau e corect si au fost adaugate 5 puncte in contul tau .", "Corect");
                a += 5;
            }
            else
            {
                Thread.Sleep(300);
                MessageBox.Show("Raspunsul tau e gresit . Incearca data viitoare , dar deocamdata au fost retrase 2 puncte din contul tau.", "Gresit");
                a -= 2;
            }
            con.Open();
            com.CommandText = "UPDATE Conturi SET Score=" + a + " WHERE Username='" + user + "'";
            this.Hide();
            f3.Show();
            com.CommandType.ToString();
            com.ExecuteNonQuery();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(sco);
            if (textBox1.Text == ras_1)
            {
                Thread.Sleep(300);
                MessageBox.Show("Bravo , raspunsul tau e corect si au fost adaugate 15 puncte in contul tau .", "Corect");
                a += 15;
            }
            else
            {
                Thread.Sleep(300);
                MessageBox.Show("Raspunsul tau e gresit . Incearca data viitoare , dar deocamdata au fost retrase 7 puncte din contul tau.", "Gresit");
                a -= 7;
            }
            con.Open();
            com.CommandText = "UPDATE Conturi SET Score=" + a + " WHERE Username='" + user + "'";
            this.Hide();
            f3.Show();
            com.CommandType.ToString();
            //com.ExecuteNonQuery();
        }
    }
}
