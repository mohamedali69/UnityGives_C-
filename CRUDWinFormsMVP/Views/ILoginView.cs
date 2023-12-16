using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Views
{
    public interface ILoginView
    {
        string Email { get; set; }
        string Password { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler Login;
    }
}
