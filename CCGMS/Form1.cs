using CCGMS.methods;
using CCGMS.view;
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

        public dashboard_view dashboardView;
        public registration_view registrationView;
        public enrollment enrollmentView;
        public dashboard mainDashboard;
        public reports_view reportsView;
        public records_view recordsView;

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
                    Task.Run(() => InitializeDashboard2());
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


        private void InitializeDashboard2()
        {
            try
            {
                // Check database connection
                using (var connection = MyCon.GetConnection())
                {
                    connection.Open(); // Attempt to open the connection
                }

                /* Initialize and preload the forms without showing them
                dashboardView = new dashboard_view();
                registrationView = new registration_view();
                enrollmentView = new enrollment();
                recordsView = new records_view();
                reportsView = new reports_view();*/

                //Form[] formsToInitialize = { dashboardView, registrationView, enrollmentView, recordsView, reportsView };
                //int totalForms = formsToInitialize.Length;
                //int progressIncrement = 100 / totalForms;

                // Show the main dashboard form after initialization
                this.Invoke((Action)(() =>
                {
                    mainDashboard = new dashboard();
                    mainDashboard.Show(); // Show the main dashboard form
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

        private void UpdateProgressBar(int value)
        {
            if (guna2ProgressBar1.InvokeRequired)
            {
                guna2ProgressBar1.Invoke(new Action(() => UpdateProgressBar(value)));
            }
            else
            {
                guna2ProgressBar1.Value = value; // Update the progress bar value
            }
        }

    }
}
