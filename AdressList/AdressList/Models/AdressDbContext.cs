using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AdressList.Models;

namespace AdressList.Models
{
    public class AdressDbContext : DbContext
    {
       public DbSet<AdressNote> AdressNotes { get; set; }
    }
}