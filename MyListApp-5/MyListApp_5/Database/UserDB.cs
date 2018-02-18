using System;
namespace MyListApp
{
	public class UserDB: User
	{
		public UserDB()
		{
		}
		public static bool LoadAll()
		{
			try
			{
				var q = DatabaseServices.Query<UserDB>(Database.connection);
				Model.Users.Clear();
				foreach (var row in q)
				{
					User user = new User();
					user.UserName = row.UserName;
					user.Password = row.Password;
					user.ServerURL = row.ServerURL;
					user.FirstName = row.FirstName;
					user.Surname = row.Surname;

					Model.Users.Add(user);
				}
			}
			catch
			{
				return false;
			}
			return true;
		}

		public static bool SaveAll()
		{
			try
			{
				DatabaseServices.DeleteAll<UserDB>(Database.connection);

				foreach (var user in Model.Users)
				{
					var row = new UserDB();
					row.UserName = user.UserName;
					row.Password = user.Password;
					row.ServerURL = user.ServerURL;
					row.FirstName = user.FirstName;
					row.Surname = user.Surname;

					Database.connection.Insert(row);
				}
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}
