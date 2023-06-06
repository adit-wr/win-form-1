using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace crudwinformadit
{
    public partial class Form1 : Form
    {
        private NpgsqlConnection connection;
        private string connString = "Server=localhost;Port=5432;User Id=postgres;Password=Maospati22!;Database=malpraktek;";
        private NpgsqlDataAdapter Adapter;
        private DataTable dt;
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowData()
        {
            try
            {
                connection = new NpgsqlConnection(connString);
                dt = new DataTable();
                Adapter = new NpgsqlDataAdapter("SELECT * FROM laptopadit", connection);
                connection.Open();
                Adapter.Fill(dt);
                connection.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error" + ex.Message);
            }
        }
        private void Createdata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO laptopadit(nama, harga, stok) " +
                "VALUES (@value1, @value2, @value3)", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);

            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success Insert data");
        }

        private void Updatedata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("UPDATE laptopadit SET nama = @value1, harga = @value2, " +
                "stok = @value3 WHERE id = @value4", connection);
            command.Parameters.AddWithValue("value1", textBox1.Text);
            command.Parameters.AddWithValue("value2", textBox2.Text);
            command.Parameters.AddWithValue("value3", textBox3.Text);
            command.Parameters.AddWithValue("value1", Convert.ToInt32(this.textBox4.Text));
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success Update data");
        }
        private void Deletedata()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connString);
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM laptopadit WHERE id=@value1", connection);
            command.Parameters.AddWithValue("value1", textBox4.Text);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Success deleted data");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Createdata();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Updatedata();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deletedata();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
    }
}