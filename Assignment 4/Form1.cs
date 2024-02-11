using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Assignment_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void DisplayContacts()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" +
                "pwd=;database=contactsdb";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string query = "SELECT * FROM contacts";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" +
                "pwd=;database=contactsdb";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string query = "INSERT INTO contacts (firstname, lastname, dob, phone) VALUES (@firstname, @lastname, @dob, @phone)";
                MySqlCommand save = new MySqlCommand(query, conn);
                save.Parameters.AddWithValue("@firstname", textFirst.Text);
                save.Parameters.AddWithValue("@lastname", textLast.Text);
                save.Parameters.AddWithValue("@dob", DateTime.Parse(textDob.Text));
                save.Parameters.AddWithValue("@phone", textPhone.Text);
                save.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DisplayContacts();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" +
                "pwd=;database=contactsdb";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string query = "UPDATE contacts SET firstname=@firstname, lastname=@lastname, dob=@dob, phone=@phone WHERE contactid=@contactid";
                MySqlCommand update = new MySqlCommand(query, conn);
                update.Parameters.AddWithValue("@firstname", textFirst.Text);
                update.Parameters.AddWithValue("@lastname", textLast.Text);
                update.Parameters.AddWithValue("@dob", DateTime.Parse(textDob.Text));
                update.Parameters.AddWithValue("@phone", textPhone.Text);
                update.Parameters.AddWithValue("@contactid", textID.Text);
                update.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DisplayContacts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=localhost;uid=root;" +
                "pwd=;database=contactsdb";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                string query = "DELETE FROM contacts WHERE contactid=@contactid";
                MySqlCommand delete = new MySqlCommand(query, conn);
                delete.Parameters.AddWithValue("@contactid", textID.Text);
                delete.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            DisplayContacts();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            DisplayContacts();
        }
    }
}
