using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GA_DatabaseFirst.Data
{
    public class GA_DatabaseFirstContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GA_DatabaseFirstContext() : base("name=GA_DatabaseFirstContext")
        {
        }

        public System.Data.Entity.DbSet<GA_DatabaseFirst.Models.Artista> Artistas { get; set; }

        public System.Data.Entity.DbSet<GA_DatabaseFirst.Models.Cancion> Cancions { get; set; }

        public System.Data.Entity.DbSet<GA_DatabaseFirst.Models.Album> Albums { get; set; }
    }
}
