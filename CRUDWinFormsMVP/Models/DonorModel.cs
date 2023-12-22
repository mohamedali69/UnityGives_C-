using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDWinFormsMVP.Models
{
    public class DonorModel
    {
        //Fields
        private int id;
        private string name;
        private string email;
        private string phoneNumber;

        //Properties - Validations
        [DisplayName("Donor ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Donor Name")]
        [Required(ErrorMessage = "Donor name is requerid")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Donor Email")]
        [Required(ErrorMessage = "Donor email is requerid")]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DisplayName("Event name")]
        [Required(ErrorMessage = "Event name is requerid")]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
