using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyListApp;
namespace MyListApp_5
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

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
                    statusLabel.TextColor = Color.Green;
                    statusLabel.Text = "Synced";
                });
            });

            MessagingCenter.Subscribe<SyncManager>(this, SyncManager.NotSynced, (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    indicator.IsVisible = false;
                    indicator.IsRunning = false;
                    statusLabel.TextColor = Color.Red;
                    statusLabel.Text = "Not Synced";
                });
            });

            MessagingCenter.Subscribe<SyncManager>(this, SyncManager.LoggedIn, (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    indicator.IsVisible = false;
                    indicator.IsRunning = false;
                    statusLabel.TextColor = Color.Green;
                    statusLabel.Text = "Logged In OK";
                });
            });

            MessagingCenter.Subscribe<SyncManager>(this, SyncManager.NotLoggedIn, (sender) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    indicator.IsVisible = false;
                    indicator.IsRunning = false;
                    statusLabel.TextColor = Color.Red;
                    statusLabel.Text = "Logged In Error";
                });
            });

        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            // TODO Validate
            User user = new User();
            user.FirstName = firstNameEntry.Text;
            user.Surname = surnameNameEntry.Text;
            user.UserName = userNameEntry.Text;
            user.Password = passwordEntry.Text;
            user.ServerURL = serverURLEntry.Text;

            IsValidServer(user.ServerURL);	// could use as test

            //  Login
            WebServices.Login(serverURLEntry.Text, userNameEntry.Text, passwordEntry.Text);

            //  REST Service 
            //WebServices.GetList<Property>(serverURLEntry.Text, userNameEntry.Text, passwordEntry.Text);

            Model.Users.Clear();
            Model.Users.Add(user);
            Database.SaveModel();
        }

        bool IsValidServer(String url)
        {
            if (WebServices.IsServerAvailable(url))
            {
                statusLabel.TextColor = Color.Green;
                statusLabel.Text = "Server Available";
                return true;
            }
            else
            {
                statusLabel.TextColor = Color.Red;
                statusLabel.Text = "Server Not Available";
                return false;
            }
        }

        //	Use to load saved user
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Model.Users.Count > 0)
            {
                firstNameEntry.Text = Model.Users[0].FirstName;
                surnameNameEntry.Text = Model.Users[0].Surname;
                userNameEntry.Text = Model.Users[0].UserName;
                passwordEntry.Text = Model.Users[0].Password;
                serverURLEntry.Text = Model.Users[0].ServerURL;
            }

        }

    }

    
    
}
