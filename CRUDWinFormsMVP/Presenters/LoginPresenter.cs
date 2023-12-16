using CRUDWinFormsMVP.Models;
using CRUDWinFormsMVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDWinFormsMVP.Presenters
{
    public class LoginPresenter
    {
        private ILoginView view;
        private IUserRepository repository;

        public LoginPresenter(ILoginView view, IUserRepository repository)
        {
            this.view = view;
            this.repository = repository;
            this.view.Login += Login;
        }

        private void Login(object sender, EventArgs e)
        {
            var model = new UserModel();
            model.Email = view.Email;
            model.Password = view.Password;
            try
            {
                new Common.ModelDataValidation().Validate(model);

                bool loginSuccessful = repository.Login(model);

                if (loginSuccessful)
                {
                    view.IsSuccessful = true;
                    view.Message = "Login successful";
                }
                else
                {
                    view.IsSuccessful = false;
                    view.Message = "Invalid email or password";
                }
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
            
        }
    }
}
