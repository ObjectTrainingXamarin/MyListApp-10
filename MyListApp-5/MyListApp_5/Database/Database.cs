//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;
using SQLite;
using System.Threading;
namespace MyListApp
{
	public static class Database
	{
		public static SQLiteConnection connection { get; set; }
		public const String dbName = "MyListApp.db";

		public static void CreateDatabase(String dbname)
		{
			connection = DatabaseServices.OpenDatabase(dbName);
			DatabaseServices.CreateTable<ItemDB>(connection);
            DatabaseServices.CreateTable<UserDB>(connection);
        }

		public static void LoadModel()
		{
			ItemDB.LoadAll();
            UserDB.LoadAll();
		}

		public static void SaveModel()
		{
			ItemDB.SaveAll();
            UserDB.SaveAll();

			//	Reload so we have item ids which are allocate by the DB.
			ItemDB.LoadAll();

            //System.Threading.Tasks.Task.Factory.StartNew(() =>
            //{
            //    Model.syncManager.Send(SyncManager.Syncing);
            //    System.Threading.Tasks.Task.Delay(5000).Wait();
            //    Model.syncManager.Send(SyncManager.Synced);
            //});
        }

	}
}
