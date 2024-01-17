using Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Repositories;
using Entities;

namespace WebAPI.Controllers
{
	[Route("api/[controller][action]")]
	[ApiController]
	public class APIController : ControllerBase
	{

		//Projet ASP.NET Core API
		//Entité + context => BDD
		//Repository => en mode dossier

		//API :
		//GetAll
		//GetById
		//Search
		//Post
		//Put
		//Delete

		private IClientBusiness _clientBusiness;

		public APIController(IClientBusiness clientBusiness)
		{
			this._clientBusiness = clientBusiness;
		}

		/// <summary>
		/// Fonction qui sert à faire un test unitaire
		/// </summary>
		/// <param name="numerateur">le chiffre du haut</param>
		/// <param name="denominateur">le chiffre du bas</param>
		/// <returns></returns>
		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(402)]
		public async Task<ActionResult> Divide(int numerateur, int denominateur)
		{
			
			if (denominateur != 0)
			{
				return Ok(numerateur / denominateur);
			}
			else
			{
				return StatusCode(402, "pas de division par 0");
			}
		}


		/// <summary>
		/// EndPoint to create a new Client, with name and description
		/// </summary>
		/// <param name="name">name of the client</param>
		/// <param name="description">description of the client</param>
		/// <returns>return an instance of client</returns>
		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(402)]
		
		public async Task<ActionResult<Client>> Create(string name, string description)
		{
			Client client = new Client() { Name = name, Description = description };
			if (await _clientBusiness.Create(client))
			{
				return Ok(client);
			}
			else
			{
				return StatusCode(402, "client non créé");
			}
		}

		[HttpGet]
		public async Task<ActionResult> Delete(int id)
		{
			if (await _clientBusiness.Delete(id))
			{
				return Ok("client supprimé");
			}
			else
			{
				return StatusCode(402, "client non supprimé");
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetById(int id)
		{
			Client client = await _clientBusiness.Read(id);
			if (client != null)
			{
				return Ok(client);
			}
			else
			{
				return StatusCode(402, "client n'existe pas");
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetByIdInclude(int id)
		{
			Client client = await _clientBusiness.ReadInclude(id);
			if (client != null)
			{
				return Ok(client);
			}
			else
			{
				return StatusCode(402, "client n'existe pas");
			}
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			List<Client> clients = await _clientBusiness.GetClients();
			if (clients != null)
			{
				return Ok(clients);
			}
			else
			{
				return StatusCode(402, "pas de clients");
			}
		}

		[HttpGet]
		public async Task<ActionResult> Search(string str)
		{
			List<Client> clients = await _clientBusiness.Search(str);
			if (clients != null)
			{
				return Ok(clients);
			}
			else
			{
				return StatusCode(402, "pas de clients");
			}
		}

		[HttpPut]
		public async Task<ActionResult> Update(Client client)
		{
			Client clt = await _clientBusiness.Read(client.Id);

			if (clt != null)
			{
				clt.Name = client.Name;
				clt.Description = client.Description;
				if (await _clientBusiness.Update(clt))
				{

					return Ok(client);
				}
				else
				{
					return StatusCode(402, "impossible de mettre à jour");
				}
			}
			else
			{
				return StatusCode(402, "pas de client" + client.Id);
			}
			}

		}
	}
