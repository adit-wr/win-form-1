using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crudwinformadit
{
    public partial class Form4 : Form
    {
        private string connString = "Server=localhost;Port=5432;User Id=postgres;Password=Maospati22!;Database=malpraktek;";

        public Form4()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO transaksi(nama, alamat, tgl, namalaptop, jml) " +
                "VALUES (@value1, @value2, @value3, @value4, @value5)", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.Parameters.AddWithValue("value4", textBox4.Text);
            command.Parameters.AddWithValue("value5", textBox5.Text);

            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Success");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
