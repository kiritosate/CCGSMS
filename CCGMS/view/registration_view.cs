using CCGMS.docs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCGMS.view
{
    public partial class registration_view : Form
    {
        public registration_view()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            enrollment enrollment = new view.enrollment();
            enrollment.ShowDialog();
=======
            enrollment fm = new enrollment();
            fm.ShowDialog();
>>>>>>> 3704f8ab23207fdd643518222346f881406b63b5
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Word_Modifier modifier = new Word_Modifier();
            modifier.ModifyAndPrintDocument();
        }
    }
}
