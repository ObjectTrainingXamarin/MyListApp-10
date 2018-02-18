//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;

namespace MyListApp
{
	public class Property
	{
		public long 	id			{ get; set; }
		public long		version		{ get; set; }
	
		public String	name		{ get; set; }
		public String	companyName	{ get; set; }

		public Property ()
		{
			id = -1;
			version = 0;
			name = "";
			companyName = "";
		}
	}
}

