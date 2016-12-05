using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdressList.Models
{
    public class AdressListRepository : IAdressListRepository
    {
        AdressDbContext context = new AdressDbContext();

        public IEnumerable<AdressNote> AdressNotes
        {
           get { return context.AdressNotes; }
        }

        public AdressNote Get(int id)
        {
            return context.AdressNotes
                .Where(r => r.Id == id).FirstOrDefault();
        }

        public AdressNote Add(AdressNote item)
        {
            item.Id = context.AdressNotes.Count() + 1;
            context.AdressNotes.Add(item);
            context.SaveChanges(); //-----
            return item;
        }

        public void Remove(int id)
        {
            AdressNote note = Get(id);
            if (note != null)
            {
                context.AdressNotes.Remove(note);
                context.SaveChanges();
            }
            else throw new Exception("null");
        }
        public bool Update(AdressNote item)
        {
            AdressNote contextItem = Get(item.Id);
            if (contextItem != null)
            {
                contextItem.PersonName = item.PersonName;
                contextItem.Adress = item.Adress;
                context.SaveChanges(); //-----------------
                return true;
            }
            else
                return false;
        }
    }
}