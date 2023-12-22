using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    public partial class DonorView : Form, IDonorView
    {
        //Fields
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        //Constructor
        public DonorView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageDonorDetail);
            btnClose.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Search
            btnSearch.Click += delegate { SearchDonor?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
              {
                  if (e.KeyCode == Keys.Enter)
                      SearchDonor?.Invoke(this, EventArgs.Empty);
              };
            //Add new
            btnAddNew.Click += delegate
            {
                AddNewDonor?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageDonorList);
                tabControl1.TabPages.Add(tabPageDonorDetail);
                tabPageDonorDetail.Text = "Add new Donor";
            };
            //Edit
            btnEdit.Click += delegate
            {
                EditDonor?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageDonorList);
                tabControl1.TabPages.Add(tabPageDonorDetail);
                tabPageDonorDetail.Text = "Edit Donor";
            };
            //Save changes
            btnSave.Click += delegate
            {
                SaveDonor?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPageDonorDetail);
                    tabControl1.TabPages.Add(tabPageDonorList);
                }
                MessageBox.Show(Message);
            };
            //Cancel
            btnCancel.Click += delegate
            {
                CancelDonor?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageDonorDetail);
                tabControl1.TabPages.Add(tabPageDonorList);
            };
            //Delete
            buttonDelete.Click += delegate
            {
                DeleteDonor?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message);
            };
            btnDelete.Click += delegate
            {               
                var result = MessageBox.Show("Are you sure you want to delete the selected Donor?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteDonor?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        //Properties
        public string DonorId
        {
            get { return txtDonorId.Text; }
            set { txtDonorId.Text = value; }
        }

        public string DonorName
        {
            get { return txtDonorName.Text; }
            set { txtDonorName.Text = value; }
        }

        public string DonorEmail
        {
            get { return txtDonorEmail.Text; }
            set { txtDonorEmail.Text = value; }
        }

        public string DonorPhoneNumber
        {
            get { return txtDonorPhoneNumber.Text; }
            set { txtDonorPhoneNumber.Text = value; }
        }

        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        //Events
        public event EventHandler SearchDonor;
        public event EventHandler AddNewDonor;
        public event EventHandler EditDonor;
        public event EventHandler DeleteDonor;
        public event EventHandler SaveDonor;
        public event EventHandler CancelDonor;

        //Methods
        public void SetDonorListBindingSource(BindingSource donorList)
        {
            dataGridView.DataSource = donorList;
        }

        //Singleton pattern (Open a single form instance)
        private static DonorView instance;

        public static DonorView GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new DonorView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void DonorView_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void txtDonorId_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPageDonorDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPageDonorList_Click(object sender, EventArgs e)
        {

        }
    }
}
