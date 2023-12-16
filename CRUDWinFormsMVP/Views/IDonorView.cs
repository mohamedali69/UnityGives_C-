using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Views
{
    public interface IDonorView
    {
        //Properties - Fields
        string DonorId { get; set; }
        string DonorName { get; set; }
        string DonorEmail { get; set; }
        string DonorPhoneNumber { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        //Events
        event EventHandler SearchDonor;
        event EventHandler AddNewDonor;
        event EventHandler EditDonor;
        event EventHandler DeleteDonor;
        event EventHandler SaveDonor;
        event EventHandler CancelDonor;

        //Methods
        void SetDonorListBindingSource(BindingSource donorList);
        void Show();//Optional

    }
}
