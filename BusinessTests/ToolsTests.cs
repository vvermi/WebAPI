using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests
{
	[TestClass()]
	public class ToolsTests
	{
		[TestMethod()]
		public void DivideTest()
		{
			// Arrange
			var numerateur = 100;
			var denominateur = 50;
			var resultExpected = 2;
			Tools tools = new Tools();

			// Action
			var result = tools.Divide(numerateur, denominateur);

			// Assert
			Assert.AreEqual(resultExpected, result);
		}

		[TestMethod()]
		public void DivideTestZero()
		{
			// Arrange
			var numerateur = 100;
			var denominateur = 0;
			var resultExpected = new ArgumentException("pas de division par 0");
			Tools tools = new Tools();
			var exception = new ArgumentException();

			// Action
			try
			{
				var result = tools.Divide(numerateur, denominateur);
			}
			catch (ArgumentException ex)
			{
				exception = ex;
			}

			// Assert
			//Assert.AreEqual(resultExpected.GetType(), exception.GetType());
			//Assert.AreEqual(resultExpected.Message, exception.Message);

			var t1 = (resultExpected.GetType(), resultExpected.Message);
			var t2 = (exception.GetType(), exception.Message);

			Assert.AreEqual(t1, t2);
		}

		[TestMethod()]
		[ExpectedException(typeof(ArgumentException), "pas de division par 0")]
		public void DivideTestZero2()
		{
			var numerateur = 100;
			var denominateur = 0;
			Tools tools = new Tools();

			tools.Divide(numerateur, denominateur);
		}
	}
}