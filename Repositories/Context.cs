using Microsoft.EntityFrameworkCore;
using Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Repositories
{
	public class Context : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		
		public Context(DbContextOptions<Context> options) : base(options) { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				//optionsBuilder.UseInMemoryDatabase("API_DB");
				optionsBuilder.LogTo(Console.WriteLine);
			}
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var clts = new List<Client>()
			{
				new Client() { Id = 1, Name = "Lilyah", Description = "Ma grande"},
				new Client() { Id = 2, Name = "Kezyah", Description = "Ma petite" },
				new Client() { Id = 3, Name = "Wakko", Description = "Papa" }
			};


			modelBuilder.Entity<Client>().HasData(clts);
			
			base.OnModelCreating(modelBuilder);
		}
	}
}
