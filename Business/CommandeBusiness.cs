using Repositories.Contracts;
using Business.Contracts;
using Entities;

namespace Business
{
	public class CommandeBusiness : ICommandeBusiness
	{
		public ICommandeRepository _commandeRepository;
		public CommandeBusiness(ICommandeRepository CommandeRepository)
		{
			_commandeRepository = CommandeRepository;

		}
		public async Task<List<Commande>> GetCommandes()
		{
			return await _commandeRepository.GetCommandes();
		}
		public async Task<bool> Create(Commande commande)
		{
			return await _commandeRepository.Create(commande);
		}
		public async Task<Commande> Read(int id)
		{
			return await _commandeRepository.Read(id);
		}
		
		public async Task<bool> Update(Commande commande)
		{
			return await _commandeRepository.Update(commande);
		}
		public async Task<bool> Delete(int id)
		{
			return await _commandeRepository.Delete(id);
		}
		public async Task<List<Commande>> Search(string str)
		{
			return await _commandeRepository.Search(str);
		}
	}
}
