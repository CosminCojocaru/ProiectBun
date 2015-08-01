using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace Proiect_Final
{
    public partial class Form1 : Form
    {
        public string user, pass,score;

        OleDbConnection con = new OleDbConnection();
        OleDbCommand com = new OleDbCommand();
        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Infoeducatie.accdb;
Persist Security Info=False;";
            
            com.Connection = con;
            button1.BackColor = Color.Black;
            button2.BackColor = Color.Black;
            Font font = new Font("TimeNewRoman", 30);
            Font font1 =  new Font("TimeNewRoman",20);
            button2.ForeColor = Color.Wheat;
            button1.ForeColor = Color.Wheat;
            button1.Font = font;
            button2.Font = font;
            button2.Text = "LOGIN";
            button1.Text = "REGISTER";
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Black;
            label1.Text = "USERNAME";
            label1.Font = font1;
            label2.ForeColor = Color.White;
            label2.BackColor = Color.Black;
            label2.Font = font1;
            label2.Text = "PASSWORD";
            textBox1.Font = font1;
            textBox1.BackColor = Color.Black;
            textBox2.Font = font1;
            textBox2.BackColor = Color.Black;
            textBox2.ForeColor = Color.White;
            textBox1.ForeColor = Color.White;
          
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register form2 = new Register();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {

                con.Open();
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
                
                if (user == textBox1.Text && pass == textBox2.Text)
                {
                    Te_crezi_IT_ist fo = new Te_crezi_IT_ist();

                    StreamWriter sw = new StreamWriter("C:\\book\\Util\\log.txt");
                    sw.WriteLine(textBox1.Text);
                    sw.WriteLine(score);
                    sw.Close();
                    fo.Show();
                    
                    this.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Utilizatorul nu a fost gasit sau ati gresit parola ", "Eroare");
            }

        }

        

    }
}
