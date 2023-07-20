using System;
using RazorSample.Models;
using Microsoft.EntityFrameworkCore;


namespace RazorSample.Context
{
    public class ApplicationDbContext : DbContext
    {
        //the parameter is a generic type 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /*create a table name students in the database 
		 * and map it to the structure defined in the "Student" model class
		 */
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "Julian", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Xia", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Kevin", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Xi", DisplayOrder = 4 }

                );
        }

    }
}

