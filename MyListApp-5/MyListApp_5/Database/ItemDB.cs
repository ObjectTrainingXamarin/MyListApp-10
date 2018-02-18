//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;
using SQLite;
using Xamarin.Forms;

namespace MyListApp
{
	public class ItemDB
	{
		[PrimaryKey, AutoIncrement]
		public long id { get; set; }
		public String Name { get; set; }
		public String Address { get; set; } 
		public String Detail { get; set; }
		public String IconSource { get; set; }

		public ItemDB()
		{
			Name = "";
			Address = "";   
			Detail = "";
			IconSource = "";
		}

		public static bool LoadAll()
		{
			try
			{
				var q = DatabaseServices.Query<ItemDB>(Database.connection);
				Model.Items.Clear();
				foreach (var itemDB in q)
				{
					Item item = new Item();
					item.id = itemDB.id;
					item.Name = itemDB.Name;
					item.Address = itemDB.Address;
					item.Detail = itemDB.Detail;
					item.Icon.Source = itemDB.IconSource;

					Model.Items.Add(item);
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
				DatabaseServices.DeleteAll<ItemDB>(Database.connection);

				foreach (var item in Model.Items)
				{
					var row = new ItemDB();
					row.id = item.id;
					row.Name = item.Name;
					row.Address = item.Address;
					row.Detail = item.Detail;
					row.IconSource = item.Icon.Source as FileImageSource;

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
