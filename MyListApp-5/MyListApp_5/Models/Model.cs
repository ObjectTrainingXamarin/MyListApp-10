//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System.Collections.ObjectModel;

namespace MyListApp
{
	/// <summary>
	/// The Model.
	/// </summary>
	public static class Model
	{
		/// <summary>
		/// The items are an observable source.
		/// </summary>
		public static ObservableCollection<Item> Items = new ObservableCollection<Item>();
        public static ObservableCollection<User> Users = new ObservableCollection<User>();

        /// <summary>
		/// The sync manager.
		/// </summary>
		public static SyncManager syncManager = new SyncManager();


        /// <summary>
        /// Add the specified item.
        /// </summary>
        /// <param name="item">Item.</param>
        public static void Add(Item item)
		{
			Items.Add(item);
		}

		/// <summary>
		/// Update the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public static void Update(Item item)
		{
			foreach (var i in Items)
			{
				if (i.id == item.id)
				{
					i.Name = item.Name;
					i.Name = item.Address;	// Added
					i.Detail = item.Detail;
					i.Icon = item.Icon;
				}
			}
		}

		/// <summary>
		/// Delete the specified item.
		/// </summary>
		/// <param name="item">Item.</param>
		public static void Delete(Item item)
		{
			Items.Remove(item);
		}
	}
}
