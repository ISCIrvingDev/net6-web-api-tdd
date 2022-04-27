using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTDD.Models;

namespace TestDrivenDesign.MockData
{
	public static class UsersMock
	{
		public static List<User> GetTestUsers() => new List<User>()
			{
				new User()
				{
					Id = 1,
					Name = "Irving",
					Email = "ISCIrvingDev@gmail.com",
					Address = new Address()
					{
						City = "Durango",
						Street = "A Durango street name",
						ZipCode = "34000"
					}
				}
			}
		;

	}
}
