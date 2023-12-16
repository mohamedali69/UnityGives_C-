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
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnEvents.Click += delegate { ShowEventView?.Invoke(this, EventArgs.Empty); };
            bntTeam.Click += delegate { ShowDonorView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowEventView;
        public event EventHandler ShowDonorView;


        private void btnEvents_Click(object sender, EventArgs e)
        {

        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bntTeam_Click(object sender, EventArgs e)
        {

        }
    }
}
