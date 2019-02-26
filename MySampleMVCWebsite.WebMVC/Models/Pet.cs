using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySampleMVCWebsite.WebMVC.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string Name { get; set; }
        public string AnimalType { get; set; }

    public class PetDBContext : DbContext
        {
            public DbSet<Pet>Pets { get; set; }
        }

    }
}