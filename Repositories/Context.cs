using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
	public class Context : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Commande> Commandes { get; set; }

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
				new Client() { Id = 2, Name = "Kezyah", Description = "Ma petite" }
			};

			Client c3 = new Client() { Id = 3, Name = "Wakko", Description = "Papa" };
			clts.Add(c3);

			var cmds = new List<Commande>()
			{
				new Commande(){ Id = 1, ClientId = 1, Description = "Clt1 cmd1" },
				new Commande(){ Id = 2, ClientId = 1, Description = "Clt1 cmd2"},
				new Commande(){ Id = 3, ClientId = 2, Description = "Clt2 cmd1" },
				new Commande(){ Id = 4, ClientId = 3, Description = "Clt3 cmd1" /*, Client = c3*/ }
			};


			modelBuilder.Entity<Client>().HasData(clts);
			modelBuilder.Entity<Commande>().HasData(cmds);


			//	// from EntityFrameworkDoc
			//	// https://learn.microsoft.com/en-us/ef/core/modeling/relationships#required-and-optional-relationships
			//	modelBuilder.Entity<Client>().HasMany(c => c.Commandes)
			//.WithOne(c => c.Client)
			//.HasForeignKey(c => c.clientId)
			//.HasPrincipalKey(c => c.Id);


			base.OnModelCreating(modelBuilder);
		}
	}
}
