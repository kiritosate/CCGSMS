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
        public dashboard()
        {
            InitializeComponent();
            timer1.Interval = 10; // Timer interval for smooth animation
            timer1.Tick += new EventHandler(timer1_Tick);
        }

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

        private async Task LoadFormInPanelAsync(Form frm)
        {
            // Ensure the panel is visible
            panel1.Visible = true;

            // Clear existing controls in the panel before loading the new form
            panel1.Controls.Clear();

            // Set the form as a child of the panel
            frm.TopLevel = false; // Required to add the form to the panel
            frm.FormBorderStyle = FormBorderStyle.None; // Remove borders
            frm.Dock = DockStyle.Fill; // Make the form fill the entire panel

            // Add the form to the panel but set opacity to 0 initially
            panel1.Controls.Add(frm);
            frm.Opacity = 0; // Start with full transparency
            frm.Show();

            // Gradually increase opacity to create a fade-in effect
            for (double opacity = 0; opacity <= 1.0; opacity += 0.1)
            {
                await Task.Delay(50); // Wait for a short time between opacity changes
                frm.Opacity = opacity;
            }

            // Ensure form is fully opaque
            frm.Opacity = 1;
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
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
