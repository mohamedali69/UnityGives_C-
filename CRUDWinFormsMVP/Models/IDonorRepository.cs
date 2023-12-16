using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
   public interface IDonorRepository
    {
        void Add(DonorModel eventModel);
        void Edit(DonorModel eventModel);
        void Delete(int id);
        IEnumerable<DonorModel> GetAll();
        IEnumerable<DonorModel> GetByValue(string value);//Searchs

    }
}
