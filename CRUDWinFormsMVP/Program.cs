using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Presenters;
using CRUDWinFormsMVP._Repositories;
using CRUDWinFormsMVP.Views;
using System.Configuration;

namespace CRUDWinFormsMVP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            ILoginView loginView = new LoginView();
            IUserRepository userRepository = new UserRepository(sqlConnectionString);
            new LoginPresenter(loginView,userRepository);
            Application.Run((Form)loginView );
        }
    }
}
