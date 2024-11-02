using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCGMS.modal
{
    public partial class modal_view : Form
    {
        public modal_view()
        {
            InitializeComponent();
        }

        public string msg
        {
            get { return guna2TextBox1.Text; } // Assuming you have a Label named lblMessage to display the message
            set { guna2TextBox1.Text = value; } // Set the message text
        }
        public static string ttl { get; set; }
        public static bool status { get; set; }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void modal_view_Load(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
    }
}
