using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUDWinFormsMVP.Models
{
    public class EventModel
    {
        //Fields
        private int id;
        private string name;
        private string type;
        private string description;

        //Properties - Validations
        [DisplayName("Event ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Event Name")]
        [Required(ErrorMessage = "Event name is requerid")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("Event Type")]
        [Required(ErrorMessage = "Event type is requerid")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [DisplayName("Event Description")]
        [Required(ErrorMessage = "Event description is requerid")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
