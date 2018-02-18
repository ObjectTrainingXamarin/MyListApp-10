using System;
namespace MyListApp
{
	public class User
	{
		public String UserName { get; set;}
		public String Password { get; set;}
		public String ServerURL { get; set;}
		public String FirstName { get; set;}
		public String Surname { get; set; }

		public User()
		{
			UserName = "";
			Password = "";
			ServerURL = "";
			FirstName = "";
			Surname = "";
		}
	}
}
