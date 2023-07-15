using System;
using Microsoft.EntityFrameworkCore;
using CMVC.Models;
namespace CMVC.Context
{
	public class ApplicationDbContext : DbContext
	{
		//the parameter is a generic type 
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{
		}

		/*create a table name students in the database 
		 * and map it to the structure defined in the "Student" model class
		 */
		public DbSet<Student> Students { get; set; }
		public DbSet<ItemCategory> ItemCategories { get; set; }
    }
}

