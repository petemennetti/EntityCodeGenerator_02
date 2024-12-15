using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Configuration;


namespace EntityCodeGenerator_02
{
    public partial class Form1 : Form
    {
        
        bool bProcessing = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            bProcessing = true;
            txtServerName.Text = "localhost";
            txtOutputPath.Text = ConfigurationManager.AppSettings["DefaultOutputPath"];
              
            LoadDatabases();
            bProcessing = false;
        }
       
        private void LoadDatabases()
        {
            bProcessing = true;
            // Connection string to your local SQL Server instance
            string connectionString = $"Server={txtServerName.Text};Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get all database names
                    string query = "SELECT name FROM sys.databases where name NOT IN ('master', 'model', 'msdb', 'tempdb') AND state = 0 order by name;"; // State = 0 means online databases

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add each database name to the ComboBox
                            cboDatabases.Items.Add(reader["name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading databases: {ex.Message}");
            }
            finally { bProcessing = false; }
        }

        private void LoadTables(string databaseName, string tableType)
        {
            // Update the connection string to use the selected database
            string connectionString = $"Server={txtServerName.Text};Database={databaseName};Integrated Security=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Adjust the query based on the tableType parameter
                    string query = $@"
                SELECT TABLE_NAME 
                FROM INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_TYPE = '{tableType}'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        lstTables.Items.Clear(); // Clear existing items

                        while (reader.Read())
                        {
                            // Add each table or view name to the CheckedListBox
                            lstTables.Items.Add(reader["TABLE_NAME"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading tables or views: {ex.Message}");
            }
        }

        private void cboDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDatabases.SelectedItem == null)
                return;

            string selectedDatabase = cboDatabases.SelectedItem.ToString();
            txtOutputPath.Text = txtOutputPath.Text + @"\" + selectedDatabase + @"\";
            if (optTables.Checked)
            {
                LoadTables(selectedDatabase, "BASE TABLE");
            }
            if (optViews.Checked)
            {
                LoadTables(selectedDatabase, "VIEW");
            }

        }

        private void optTables_CheckedChanged(object sender, EventArgs e)
        {
            if (cboDatabases.SelectedItem == null)
                return;

            string selectedDatabase = cboDatabases.SelectedItem.ToString();

            if (optTables.Checked)
            {
                LoadTables(selectedDatabase, "BASE TABLE");
            }

        }

        private void optViews_CheckedChanged(object sender, EventArgs e)
        {
            if (cboDatabases.SelectedItem == null)
                return;

            string selectedDatabase = cboDatabases.SelectedItem.ToString();

            if (optViews.Checked)
            {
                LoadTables(selectedDatabase, "VIEW");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cboDatabases.SelectedItem == null)
            {
                MessageBox.Show("Please select a database.");
                return;
            }

            string selectedDatabase = cboDatabases.SelectedItem.ToString();

            if (lstTables.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please check at least one table or view to process.");
                return;
            }
            if(!Directory.Exists(txtOutputPath.Text + @"\"))
            {
                Directory.CreateDirectory(txtOutputPath.Text + @"\");
            }
            foreach (var item in lstTables.CheckedItems)
            {
                string tableNameOrViewName = item.ToString();

                // Call the static method to generate the entity file
                EntityFileGenerator.CreateEntityFile(
                txtNameSpace.Text,
                ".",
                cboDatabases.Text,
                tableNameOrViewName,
                txtOutputPath.Text + @"\" + tableNameOrViewName + ".cs"

                ); // Call the static method
            }
             
            MessageBox.Show("Entity generation process completed!");
        }
    }
}
