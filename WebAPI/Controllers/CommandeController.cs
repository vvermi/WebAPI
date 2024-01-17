using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class CommandeController : Controller
	{
		private ICommandeBusiness _commandeBusiness;

		public CommandeController(ICommandeBusiness commandeBusiness)
		{
			this._commandeBusiness = commandeBusiness;
		}

		/// <summary>
		/// EndPoint to create a new Commande, with id of the client and description
		/// </summary>
		/// <param clientId="ClientId">id of the client</param>
		/// <param description="description">description of the commande</param>
		/// <returns>return an instance of commande</returns>
		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(402)]

		public async Task<ActionResult<Commande>> Create(int clientId, string description)
		{
			Commande commande = new Commande() { ClientId = clientId, Description = description };
			if (await _commandeBusiness.Create(commande))
			{
				return Ok(commande);
			}
			else
			{
				return StatusCode(402, "commande non créé");
			}
		}

		[HttpGet]
		public async Task<ActionResult> Delete(int id)
		{
			if (await _commandeBusiness.Delete(id))
			{
				return Ok("commande supprimé");
			}
			else
			{
				return StatusCode(402, "commande non supprimé");
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetById(int id)
		{
			Commande commande = await _commandeBusiness.Read(id);
			if (commande != null)
			{
				return Ok(commande);
			}
			else
			{
				return StatusCode(402, "commande n'existe pas");
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			List<Commande> commandes = await _commandeBusiness.GetCommandes();
			if (commandes != null)
			{
				return Ok(commandes);
			}
			else
			{
				return StatusCode(402, "pas de commandes");
			}
		}

		[HttpGet]
		public async Task<ActionResult> Search(string str)
		{
			List<Commande> commandes = await _commandeBusiness.Search(str);
			if (commandes != null)
			{
				return Ok(commandes);
			}
			else
			{
				return StatusCode(402, "pas de commandes");
			}
		}

		[HttpPut]
		public async Task<ActionResult> Update(Commande commande)
		{
			Commande clt = await _commandeBusiness.Read(commande.Id);

			if (clt != null)
			{
				clt.ClientId = commande.ClientId;
				clt.Description = commande.Description;
				if (await _commandeBusiness.Update(clt))
				{

					return Ok(commande);
				}
				else
				{
					return StatusCode(402, "impossible de mettre à jour");
				}
			}
			else
			{
				return StatusCode(402, "pas de commande" + commande.Id);
			}
		}

	}
}

