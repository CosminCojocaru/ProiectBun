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
    public partial class Form12 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        OleDbCommand comm = new OleDbCommand();
        string user, pass, score;
        public Form12()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            button1.Visible = false;
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader sw1 = new System.IO.StreamReader(@"C:\book\Util\log.txt");
            string a = sw1.ReadLine();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Infoeducatie.accdb;
Persist Security Info=False;";
           
            conn.Open();
            comm.Connection = conn;
            comm.CommandText = @"SELECT * FROM Conturi Where Username='" + a + "'";
            comm.CommandType = System.Data.CommandType.Text;
            OleDbDataReader reader = comm.ExecuteReader();
            
            while (reader.Read())
            {
                user = reader.GetString(1);
                pass = reader.GetString(2);
                score = reader["score"].ToString();
                //MessageBox.Show("'"+score+"'");

            }
            label3.Text = score;
            label1.Visible = true;
            Thread.Sleep(300);
            label2.Visible = true;
            Thread.Sleep(500);
            label3.Visible = true;
            Thread.Sleep(300);
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Te_crezi_IT_ist t = new Te_crezi_IT_ist();
            t.Show();
        }
    }
}
