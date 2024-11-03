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

namespace CCGMS.view
{
    public partial class records_view : Form
    {
        private BindingSource bindingSource = new BindingSource();
        private MyFetch fetchService;
        private String StudentId;
        public records_view()
        {
            InitializeComponent();
            fetchService = new MyFetch();
        }
        
        private void records_view_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView(guna2DataGridView1);
        }

        private void LoadDataIntoDataGridView(DataGridView dataGridView)
        {
            MySqlDataAdapter adapter = fetchService.GetIndividualData();
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

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int columnIndex = e.ColumnIndex;

                DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];

                // Find the column index for "StudentId" column by name
                int studentIdColumnIndex = guna2DataGridView1.Columns["Student_Id"].Index;

                // Retrieve the StudentId value based on its column index
                StudentId = row.Cells[studentIdColumnIndex].Value?.ToString() ?? "N/A";

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

                //MessageBox.Show($"Student Id: {StudentId}: {row.Cells[1]}");
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
