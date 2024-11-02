using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CCGMS
{
    public partial class loading_form : Form
    {
        public loading_form()
        {
            InitializeComponent();
            // Set up the progress bar properties (min, max, step)
            guna2ProgressBar1.Minimum = 0;
            guna2ProgressBar1.Maximum = 100;
        }

        // Method to update the progress bar value from another thread
        public void UpdateProgress(int progress)
        {
            guna2ProgressBar1.Value = progress;
        }

        private void loading_form_Load(object sender, EventArgs e)
        {

        }
    }
}
