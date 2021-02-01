using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorServerSide.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerSide.Database
{
    public class InMemoryContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        public InMemoryContext(DbContextOptions options) : base(options)
        {
        }
    }
}

