//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;
using Xamarin.Forms;

namespace MyListApp
{
	/// <summary>
	/// Image list cell used as a template.
	/// </summary>
	public class ImageListCell: ViewCell
	{
		public ImageListCell()
		{
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Start,
				WidthRequest = 40,
				HeightRequest = 40
			};

			//	Bind the image to the source.
			image.SetBinding(Image.SourceProperty, new Binding("Icon.Source"));

			var nameLayout = CreateNameLayout();

			//	We want the image to take the height cell. |=
			var viewLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.Center,
				Children = { image, nameLayout },
				Padding = new Thickness (15, 10),
				Spacing = 0
			};

			View = viewLayout;
		}

		/// <summary>
		/// Creates the name layout.
		/// </summary>
		/// <returns>The name layout.</returns>
		public static StackLayout CreateNameLayout()
		{
			var textLabel = new Label {
				HorizontalOptions= LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 14,
				TextColor = Color.Gray                              
			};
			var addressLabel = new Label	// Added
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 14,
				TextColor = Color.Gray
			};
			var detailedLabel = new Label {
				HorizontalOptions= LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 12,
				TextColor = Color.Blue
			};
				
			textLabel.SetBinding(Label.TextProperty, "Name");
			addressLabel.SetBinding(Label.TextProperty, "Address");	// Added
			detailedLabel.SetBinding(Label.TextProperty, "Detail");

			var nameLayout = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(10,0),	// Horizonal padding
				Spacing = 0,
				Children = { textLabel, addressLabel, detailedLabel }
			};

			return nameLayout;
		}
	}
}
