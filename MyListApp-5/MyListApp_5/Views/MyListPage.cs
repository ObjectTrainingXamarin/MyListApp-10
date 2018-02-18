//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyListApp
{
	/// <summary>
	/// My list page.
	/// </summary>
	public class MyListPage : ContentPage
	{
		ToolbarItem addTBI = new ToolbarItem()
		{
			Text = "Add",
			Icon = "",
			Order = ToolbarItemOrder.Primary,
		};

        ActivityIndicator indicator = new ActivityIndicator()
        {
            IsRunning = false,
            IsVisible = false
        };


        ListView listView = new ListView();

		/// <summary>
		/// Refresh the list.
		/// </summary>
		private void Refresh()
		{
			if (listView == null)
				return;

			//	Force a listview refresh.
			if (listView.SelectedItem != null)
				listView.SelectedItem = null;
			listView.ItemsSource = null;
			listView.ItemsSource = Model.Items;
		}

		public MyListPage()
		{
			Title = "My List";

			//	Set up a template
			listView.ItemsSource = Model.Items;
			listView.ItemTemplate = new DataTemplate(typeof(ImageListCell));
			listView.RowHeight = 80;	// Modified

			Content = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children = {
                        indicator,
						listView
					}
			};

			//Model.GetData();
			Refresh();

			// Events
			addTBI.Command = new Command(() => OnAddTBI());
			ToolbarItems.Add(addTBI);
			listView.ItemSelected += OnItemSelected;

            MessagingCenter.Subscribe<SyncManager>(this, SyncManager.Syncing, (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    indicator.IsVisible = true;
                    indicator.IsRunning = true;

                });
            });

            MessagingCenter.Subscribe<SyncManager>(this, SyncManager.Synced, (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    indicator.IsVisible = false;
                    indicator.IsRunning = false;
                });
            });
        }

		/// <summary>
		/// On the item selected.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		async private void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			//	Stop false events.
			if (args.SelectedItem == null)
				return;

			//	Get the list item 
			var item = (Item)args.SelectedItem;

			var action = await DisplayActionSheet(item.Name, "Cancel", "Delete", "Update");
			switch (action)
			{
				case "Cancel":
					break;
				case "Delete":
					Model.Delete(item);
					break;
				case "Update":
					await Navigation.PushAsync(new ItemPage(item, false));
					break;
				default:
					break;
			}

			//	Deselect if you like
			listView.SelectedItem = null;
		}

		/// <summary>
		/// Add a new Item.
		/// </summary>
		private void OnAddTBI()
		{
			Navigation.PushAsync(new ItemPage(new Item(), true));
		}

		// Good practice
		protected override void OnAppearing()
		{
			base.OnAppearing();
			Refresh();
		}
	}
}

