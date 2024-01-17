using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Commande
	{
		public int Id { get; set; }
		public string? Description { get; set; }

		[ForeignKey("Client")]
		public int ClientId { get; set; }
		public Client Client { get; set; }
	}
}
