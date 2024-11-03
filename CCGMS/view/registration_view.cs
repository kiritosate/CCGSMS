using CCGMS.docs;
using CCGMS.methods;
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
        private MyFetch fetchService;
        public registration_view()
        {
            InitializeComponent();
            fetchService = new MyFetch();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            enrollment enrollment = new view.enrollment();
            enrollment.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Word_Modifier modifier = new Word_Modifier();
            modifier.ModifyAndPrintDocument();
        }

        private void registration_view_Load(object sender, EventArgs e)
        {
            var studentRecords = fetchService.GetAllIndividualRecords();

            // Format the data for display
            string formattedData = fetchService.FormatStudentRecords(studentRecords);

            // Display the data in the TextBox (assuming your TextBox is named txtDataDisplay)
            textBox1.Text = formattedData;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
