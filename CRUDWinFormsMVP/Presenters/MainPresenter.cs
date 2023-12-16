using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDWinFormsMVP.Views;
using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP._Repositories;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowEventView += ShowEventsView;
            this.mainView.ShowDonorView += ShowDonorsView;
        }

        private void ShowEventsView(object sender, EventArgs e)
        {
            IEventView view = EventView.GetInstace((MainView)mainView);
            IEventRepository repository = new EventRepository(sqlConnectionString);
            new EventPresenter(view, repository);
        }
        
        private void ShowDonorsView(object sender, EventArgs e)
        {
            IDonorView view = DonorView.GetInstace((MainView)mainView);
            IDonorRepository repository = new DonorRepository(sqlConnectionString);
            new DonorPresenter(view, repository);
        }
    }
}
