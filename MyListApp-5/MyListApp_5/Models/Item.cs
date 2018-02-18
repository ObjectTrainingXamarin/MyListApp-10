//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;
using Xamarin.Forms;

namespace MyListApp
{
	/// <summary>
	/// The Item.
	/// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
	/// Written by Tim Hastings.
	/// </summary>
	public class Item
	{
		public long id { get; set; }
		public String Name { get; set; }
		public String Address { get; set; }	// Added
		public String Detail { get; set; }
		public Image Icon { get; set; }

		public Item()
		{
			//	Always initiate instance variables.
			id = 0;
			Name = "";
			Address = "";	
			Detail = "";
			Icon = new Image() { Source = "avatar.png"};
		}
	}
}
