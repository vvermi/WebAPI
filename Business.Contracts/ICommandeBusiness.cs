using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
	public interface ICommandeBusiness
	{
		public Task<List<Commande>> GetCommandes();
		public Task<bool> Create(Commande commande);
		public Task<Commande> Read(int id);

		

		public Task<bool> Update(Commande commande);
		public Task<bool> Delete(int id);
		Task<List<Commande>> Search(string name);
	}
}
