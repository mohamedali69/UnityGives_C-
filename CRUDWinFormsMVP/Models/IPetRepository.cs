using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
   public interface IPetRepository
    {
        void Add(EventModel eventModel);
        void Edit(EventModel eventModel);
        void Delete(int id);
        IEnumerable<EventModel> GetAll();
        IEnumerable<EventModel> GetByValue(string value);//Searchs

    }
}
