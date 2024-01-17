using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Contracts;

namespace Business
{
	public class Tools : ITools
	{
		public int Divide(int numerateur, int denominateur)
		{
			if (denominateur == 0)
			{
				throw new ArgumentException("pas de division par 0");
			}
			else
			{
				return numerateur / denominateur;
			}
		}
	}
}
