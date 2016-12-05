using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdressList.Models;

namespace AdressList.Models
{
    public interface IAdressListRepository
    {
        IEnumerable<AdressNote> AdressNotes { get; }
        AdressNote Get(int id);
        AdressNote Add(AdressNote item);
        void Remove(int id);
        bool Update(AdressNote item);
    }
}
