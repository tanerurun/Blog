using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework.Context
{
    public class DataContext : DbContext
    {
      
        public DbSet<Author> Author { get; set; }
        public DbSet<Article> Article { get; set; }
    }
}
