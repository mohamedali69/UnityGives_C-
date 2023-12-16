using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public class UserModel
    {
        private string email;
        private string password;



        [DisplayName("User Email")]
        [Required(ErrorMessage = "User Email is requerid")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DisplayName("User Password")]
        [Required(ErrorMessage = "User password is requerid")]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
