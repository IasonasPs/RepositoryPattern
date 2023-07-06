using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.EfCore
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Star> Stars { get; set; } = default!;
    }
}
