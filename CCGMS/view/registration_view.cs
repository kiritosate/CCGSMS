using CCGMS.docs;
using CCGMS.methods;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
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
        private BindingSource bindingSource = new BindingSource();
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
            
            //Word_Modifier modifier = new Word_Modifier();
            //modifier.ModifyAndPrintDocument();
        }

        private void registration_view_Load(object sender, EventArgs e)
        {
            //var studentRecords = fetchService.GetAllIndividualRecords();

            // Format the data for display
            //string formattedData = fetchService.FormatStudentRecords(studentRecords);

            // Display the data in the TextBox (assuming your TextBox is named txtDataDisplay)
            //textBox1.Text = formattedData;
            /*
            var studentCounts = fetchService.GetStudentCountByYearAndSex();

            foreach (var entry in studentCounts)
            {
                //Console.WriteLine($"{entry.Key}: {entry.Value}");
                // Output each key-value pair in the format "1st Year - Male: count" etc.
                textBox1.Text += $"{entry.Key}: {entry.Value}\r\n";
            }*/
            LoadDataIntoDataGridView(guna2DataGridView1);
        }
        private void LoadDataIntoDataGridView(DataGridView dataGridView)
        {
            MySqlDataAdapter adapter = fetchService.GetIndividualDataPending();
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);
            
            bindingSource.DataSource = dataTable;   // Fill the DataTable with data
            dataGridView.DataSource = bindingSource; // Bind the DataTable to the DataGridView
            AddActionColumns();

        }

        private void AddActionColumns()
        {
            // Create the View column
            DataGridViewImageColumn viewColumn = new DataGridViewImageColumn();
            viewColumn.HeaderText = "View";
            viewColumn.Name = "imgView";
            viewColumn.Image = Properties.Resources.eye_96px; // Replace with your resource image
            viewColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            guna2DataGridView1.Columns.Add(viewColumn);

            // Create the Edit column
            DataGridViewImageColumn editColumn = new DataGridViewImageColumn();
            editColumn.HeaderText = "Edit";
            editColumn.Name = "imgEdit";
            editColumn.Image = Properties.Resources.pencil_96px; // Replace with your resource image
            editColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            guna2DataGridView1.Columns.Add(editColumn);

            // Create the Delete column
            DataGridViewImageColumn deleteColumn = new DataGridViewImageColumn();
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Name = "imgDelete";
            deleteColumn.Image = Properties.Resources.delete_trash_96px; // Replace with your resource image
            deleteColumn.ImageLayout = DataGridViewImageCellLayout.Zoom; // Optionally set layout
            guna2DataGridView1.Columns.Add(deleteColumn);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int columnIndex = e.ColumnIndex;

                // Check if the clicked column is one of the action columns
                if (guna2DataGridView1.Columns[columnIndex].Name == "imgView")
                {
                    MessageBox.Show("You clicked to view the record.");
                }
                else if (guna2DataGridView1.Columns[columnIndex].Name == "imgEdit")
                {
                    MessageBox.Show("You clicked to edit the record.");
                }
                else if (guna2DataGridView1.Columns[columnIndex].Name == "imgDelete")
                {
                    MessageBox.Show("You clicked to delete the record.");
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = guna2TextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                bindingSource.Filter = $"Student_ID LIKE '%{searchText}%' OR " +
                                       $"Course LIKE '%{searchText}%' OR " +
                                       $"Year LIKE '%{searchText}%' OR " +
                                       $"Firstname LIKE '%{searchText}%' OR " +
                                       $"Middlename LIKE '%{searchText}%' OR " +
                                       $"Lastname LIKE '%{searchText}%' OR " +
                                       $"Sex LIKE '%{searchText}%'";
            }
            else
            {
                bindingSource.RemoveFilter();
            }
        }
    }
}
