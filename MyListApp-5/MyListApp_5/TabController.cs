using System;

using Xamarin.Forms;
using MyListApp_5;

namespace MyListApp
{
	/// <summary>
	/// Tab controller.
	/// </summary>
	public class TabController : TabbedPage
	{
		MyListPage myListPage = new MyListPage();
		SettingsPage settingsPage = new SettingsPage();
		public TabController()
		{
			Children.Add(myListPage);
			Children.Add(settingsPage);

			Title = "My List App";

			//	Handle page selections
			CurrentPageChanged += OnCurrentPageChanged;
		}

		// You may change the title.
		void OnCurrentPageChanged(object obj, EventArgs args)
		{
			if (CurrentPage == myListPage)
				Title = "My List App";
			else
				Title = "Settings";
		}
	}
}

