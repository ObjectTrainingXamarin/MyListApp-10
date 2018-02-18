using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using MyListApp;

namespace MyListApp_5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            if (!DatabaseServices.DatabaseExists(Database.dbName))
            {
                //	This is the first time so create the DB
                Database.CreateDatabase(Database.dbName);
            }

            MainPage = new NavigationPage(new TabController());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Database.connection = DatabaseServices.OpenDatabase(Database.dbName);
            Database.LoadModel();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Database.SaveModel();
            DatabaseServices.CloseDatabase(Database.connection);
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            Database.connection = DatabaseServices.OpenDatabase(Database.dbName);
            Database.LoadModel();
        }
    }
}
