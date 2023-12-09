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
        }

        public event EventHandler ShowEventView;
        public event EventHandler ShowOwnerView;
        public event EventHandler ShowVetsView;

        private void btnEvents_Click(object sender, EventArgs e)
        {

        }

        private void MainView_Load(object sender, EventArgs e)
        {

        }
    }
}
