using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repositories
{
	public class CommandeRepository : ICommandeRepository
	{
		private Context _context;
		public CommandeRepository(Context context)
		{
			_context = context;
		}
		public async Task<List<Commande>> GetCommandes()
		{
			return await _context.Commandes.ToListAsync();
		}
		public async Task<bool> Create(Commande commande)
		{
			try
			{
				_context.Commandes.Add(commande);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public async Task<Commande> Read(int id)
		{
			return await _context.Commandes.FirstOrDefaultAsync(c => c.Id == id);
		}

		
		public async Task<bool> Update(Commande commande)
		{
			try
			{
				var commandeToEdit = await _context.Commandes.FirstOrDefaultAsync(c => c.Id == commande.Id);
				commandeToEdit.Description = commande.Description;
				
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public async Task<bool> Delete(int id)
		{
			try
			{
				_context.Commandes.Remove(await _context.Commandes.FirstOrDefaultAsync(c => c.Id == id));
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public async Task<List<Commande>> Search(string str)
		{
			return await _context.Commandes.Where(c => (c.Id.ToString()).Contains(str) || c.Description.Contains(str)).ToListAsync();
		}

	}
}
