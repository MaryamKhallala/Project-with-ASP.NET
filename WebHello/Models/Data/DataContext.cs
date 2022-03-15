

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; 

namespace WebHello
{
    public class DataContext: DbContext
    {
        public DbSet<Livre> Livres { get; set; }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }

        
    }
}