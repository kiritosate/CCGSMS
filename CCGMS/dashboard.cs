using CCGMS.view;
using Guna.UI2.WinForms;
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
    public partial class dashboard : Form
    {

        private Form dashboardView;
        private Form registrationView;
        private Form enrollmentView;
        private Form reportsView;
        private Form recordsView;

        public dashboard()
        {
            InitializeComponent();

            timer1.Interval = 10; // Timer interval for smooth animation
            timer1.Tick += new EventHandler(timer1_Tick);
        }
            /*
            public dashboard(Form dashboardView, Form registrationView, Form enrollmentView,Form recordsView, Form reportsView)
            {
                InitializeComponent();
                /*
                this.dashboardView = dashboardView;
                this.registrationView = registrationView;
                this.enrollmentView = enrollmentView;
                this.reportsView = reportsView;
                this.recordsView = recordsView;

                timer1.Interval = 10; // Timer interval for smooth animation
                timer1.Tick += new EventHandler(timer1_Tick);
            }*/
            private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
        }
        private bool isCollapsed = false; // To keep track of the sidebar state
        private int expandedWidth = 200; // Expanded width of the sidebar
        private int collapsedWidth = 50; // Collapsed width of the sidebar
        

        // Toggle button click event
        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        // Timer Tick event to handle the animation
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                guna2Panel1.Width += 10; // Expand the panel width step by step
                if (guna2Panel1.Width >= expandedWidth)
                {
                    timer1.Stop(); // Stop the timer when fully expanded
                    isCollapsed = false; // Update the state to "expanded"
                }
            }
            else
            {
                guna2Panel1.Width -= 10; // Collapse the panel width step by step
                if (guna2Panel1.Width <= collapsedWidth)
                {
                    timer1.Stop(); // Stop the timer when fully collapsed
                    isCollapsed = true; // Update the state to "collapsed"
                }
            }
        }
        /*
        private void ShowFormInDashboard(Form formToShow)
        {
            if (this.InvokeRequired) // Check if the call is from a different thread
            {
                this.Invoke(new Action(() => ShowFormInDashboard(formToShow)));
                return; // Return early to prevent further execution
            }

            // Close any existing forms in the panel if necessary
            foreach (Control control in this.Controls)
            {
                if (control is Form existingForm && existingForm != formToShow) // Exclude the form to show
                {
                    existingForm.Close(); // Close the existing form
                }
            }

            // Show the form in a panel or as a standalone
            formToShow.TopLevel = false; // Set to false if you want to show it in a panel
            formToShow.FormBorderStyle = FormBorderStyle.None; // Remove borders if needed
            formToShow.Dock = DockStyle.Fill; // Fill the panel or form
            panel1.Controls.Add(formToShow); // Add to the current form's controls
            formToShow.Show(); // Show the form
        }
        
        private async Task LoadFormInPanelAsync(Form form)
        {
            await Task.Run(() =>
            {
                // Simulate some background work
                System.Threading.Thread.Sleep(300); // Replace with actual loading logic
            });

            ShowFormInDashboard(form); // Show the form safely
        }
         */

        private async Task LoadFormInPanelAsync(Form form)
        {
            // Clear existing controls from the panel
            panel1.Controls.Clear();

            // Set up the form to fit within the panel
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Add the form to the panel and display it
            panel1.Controls.Add(form);
            form.Show();

            // Simulate an asynchronous load (if needed)
            await Task.Delay(300); // Adjust delay as needed
        }


        

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            //await LoadFormInPanelAsync(Form1.dash);
            await LoadFormInPanelAsync(new dashboard_view());
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure to Logout?", "Logout", MessageBoxButtons.YesNo);
            
            if(dg == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                
            }
        }

        private async void guna2Button2_Click(object sender, EventArgs e)
        {
            await LoadFormInPanelAsync(new registration_view());
        }

        private async void dashboard_Load(object sender, EventArgs e)
        {
            await LoadFormInPanelAsync(new dashboard_view());
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            await LoadFormInPanelAsync(new records_view());
        }

        private async void guna2Button4_Click(object sender, EventArgs e)
        {
            await LoadFormInPanelAsync(new reports_view());
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
