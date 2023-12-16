using CRUDWinFormsMVP.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUDWinFormsMVP.Views
{
    public partial class LoginView : Form, ILoginView
    {
        private string message;
        private bool isSuccessful;
        public LoginView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }
        public string Email
        {
            get { return emailBox.Text; }
            set { emailBox.Text = value; }
        }
        public string Password
        {
            get { return passwordBox.Text; }
            set{passwordBox.Text = value;}
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
        private void AssociateAndRaiseViewEvents()
        {   //test if login button is working
            loginButton.Click += delegate { Login?.Invoke(this, EventArgs.Empty); 
            if(isSuccessful == true)
            {
                    MessageBox.Show(message);
                    this.Hide();
                    string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                    IMainView view = new MainView();
                    new MainPresenter(view, sqlConnectionString);
                    ((Form)view).ShowDialog();
                    this.Close();
                }
            else
            {
                MessageBox.Show(message);
            }
            };
        }
        public event EventHandler Login;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginView_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {

        }
    }
}
