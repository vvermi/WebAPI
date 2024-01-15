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
		[HttpPost]
		public async Task<ActionResult> Create(string name, string description)
		{
			Client client = new Client() { Name = name, Description = description };
			if (await _clientBusiness.Create(client))
			{
				return Ok("client créé");
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

	}
}
