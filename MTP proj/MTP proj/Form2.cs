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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace MTP_proj
{
    public partial class Form2 : Form


    {
        private string connectionString = "Data Source=Daniel\\SQLEXPRESS;" + "Initial Catalog=products;" + "Integrated Security=True;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadData();
        }




        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", nameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Price", priceTextBox.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            LoadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE ID = @ID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idTextBox.Text);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            LoadData();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Products WHERE Name LIKE '%' + @Name + '%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@Name", searchTextBox.Text);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void searchTextBox_Click(object sender, EventArgs e)
        {
            searchTextBox.Text= string.Empty;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.Text=="Search")
                {
                searchTextBox.Text = "";
            }
        }

        private void idTextBox_Enter(object sender, EventArgs e)
        {
            if (idTextBox.Text == "ID")
            {
                idTextBox.Text = "";
            }
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            if (nameTextBox.Text == "Name")
            {
                nameTextBox.Text = "";
            }
        }

        private void priceTextBox_Enter(object sender, EventArgs e)
        {
            if (priceTextBox.Text == "Price")
            {
                priceTextBox.Text = "";
            }
        }
    }
}