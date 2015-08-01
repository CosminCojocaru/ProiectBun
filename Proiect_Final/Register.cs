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

namespace Proiect_Final
{
    public partial class Register : Form
    {
        OleDbConnection con = new OleDbConnection();
        OleDbCommand com = new OleDbCommand();
        public Register()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Infoeducatie.accdb;
Persist Security Info=False;";

            com.Connection = con;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form = new Register();
            form.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                com.CommandText = @"INSERT INTO Conturi([Username] , [pass])VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
                com.CommandType = System.Data.CommandType.Text;
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Te-ai inregistrat cu scces");
            }
            catch (Exception ex)
            {
                MessageBox.Show("S-a produs o eroare in urma inregistrarii", "");

            }
        }
    }
}
