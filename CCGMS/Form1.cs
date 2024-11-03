using CCGMS.methods;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCGMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(guna2ImageCheckBox1.Checked)
            {
                guna2TextBox2.PasswordChar = '\0';
            }
            else
            {
                guna2TextBox2.PasswordChar = '*';
            } 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = MyCon.GetConnection();

            try
            {
                string username = guna2TextBox1.Text;
                string password = guna2TextBox2.Text;

                string sql = "SELECT COUNT(*) FROM tbl_admin_account WHERE Admin_Name = @username AND Admin_Password = @password";
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    // Hide the login form
                    this.Hide();
                    Task.Run(() => InitializeDashboard());
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void InitializeDashboard()
        {
            try
            {
                // Check database connection
                using (var connection = MyCon.GetConnection())
                {
                    connection.Open(); // Attempt to open the connection
                }

                // Simulate the initialization of all views
                string[] viewsToInitialize = { "DashboardView", "RegistrationView", "EnrollmentView", "Dashboard" };
                for (int i = 0; i < viewsToInitialize.Length; i++)
                {
                    // Simulate work (e.g., loading resources, setting up UI, etc.)
                    System.Threading.Thread.Sleep(300); // Simulate delay

                    // Safely update the progress bar on the UI thread
                    int progressValue = (i + 1) * 25; // Increment progress
                    this.Invoke((Action)(() =>
                    {
                        guna2ProgressBar1.Value = progressValue; // Update the progress bar value
                    }));
                }

                // Show the dashboard after initialization completes
                this.Invoke((Action)(() =>
                {
                    dashboard dashboard = new dashboard(); // Assuming Dashboard is the form you want to show
                    dashboard.Show(); // Call showForm to display the Dashboard form
                }));
            }
            catch (Exception ex)
            {
                this.Invoke((Action)(() =>
                {
                    MessageBox.Show("Error initializing dashboard: " + ex.Message);
                }));
            }
        }
        

    }
}
