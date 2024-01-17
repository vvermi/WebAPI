
using Entities;

namespace Repositories.Contracts
{
	public interface ICommandeRepository
	{
		Task<List<Commande>> GetCommandes();
		Task<bool> Create(Commande commande);
		Task<Commande> Read(int id);
		
		Task<bool> Update(Commande commande);
		Task<bool> Delete(int id);
		Task<List<Commande>> Search(string str);
	}
}
