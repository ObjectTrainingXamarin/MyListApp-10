// 
// Copyright (C) 2015 Smart Device Labs - All Rights Reserved.
// The contents of this file are proprietary and confidential.
// Unauthorized copying of this file, via any medium, is strictly prohibited.
// Written by timothy.e.hastings@gmail.com
//
using System;
using Xamarin.Forms;
using SQLite;

namespace MyListApp
{
	/// <summary>
	/// Database dependency services.
	/// </summary>
	public static class DatabaseServices
	{
		/// <summary>
		/// Opens the database.
		/// </summary>
		/// <returns>The database connection.</returns>
		/// <param name="dbname">Dbname.</param>
		public static SQLiteConnection OpenDatabase(String dbname)
		{
			return(DependencyService.Get<IPlatformServices> ().GetConnection (dbname));
		}

		//public static bool CreateDatabase(String dbname)
		//{
		//	return(DependencyService.Get<IPlatformServices> ().CreateDatabase (dbname));
		//}

		public static bool DatabaseExists (String dbname)
		{
			return(DependencyService.Get<IPlatformServices> ().DatabaseExists (dbname));
		}


		public static bool DeleteDatabase (String dbname)
		{
			return(DependencyService.Get<IPlatformServices> ().DeleteDatabase (dbname));
		}

		/// <summary>
		/// Closes the database.
		/// </summary>
		/// <returns>null.</returns>
		/// <param name="connection">Connection.</param>
		public static SQLiteConnection CloseDatabase (SQLiteConnection connection)
		{
			if (connection != null)
				connection.Close ();

			return null;	// Other fuctions know it is closed.
		}

		/// <summary>
		/// Check if a table exists.
		/// </summary>
		/// <returns><c>true</c>, if exists was tabled, <c>false</c> otherwise.</returns>
		/// <param name="connection">Connection.</param>
		/// <param name="tableName">Table name.</param>
		public static bool TableExists(SQLiteConnection connection, String tableName)
		{
			if (connection == null)
				return false;

			var info = connection.GetTableInfo (tableName);
			if (info.Count == 0)
				return false;

			return true;
		}

		/// <summary>
		/// Creates the table.
		/// </summary>
		/// <returns><c>true</c>, if table was created, <c>false</c> otherwise.</returns>
		/// <param name="connection">Connection.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static bool CreateTable <T>(SQLiteConnection connection) 
		{
			if (connection == null)
				return false;

			if (connection.CreateTable<T> () == 0)
				return true;
			else
				return false;
		}

		/// <summary>
		/// Drops the table.
		/// </summary>
		/// <returns><c>true</c>, if table was droped, <c>false</c> otherwise.</returns>
		/// <param name="connection">Connection.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static bool DropTable <T> (SQLiteConnection connection) 
		{
			if (connection == null)
				return false;

			if (connection.DropTable<T> () == 0)
				return true;
			else
				return false;
		}


		/// <summary>
		/// Deletes all rows in table specified by class T.
		/// </summary>
		/// <returns><c>true</c>, if all was deleted, <c>false</c> otherwise.</returns>
		/// <param name="connection">Connection.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static bool DeleteAll <T>(SQLiteConnection connection)
		{
			if (connection == null)
				return false;

			connection.DeleteAll<T> ();
			return true;
		}

		/// <summary>
		/// Query the specified Table T.
		/// Returns all rows
		/// </summary>
		/// <param name="connection">Connection.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static TableQuery<T> Query <T> (SQLiteConnection connection) where T: new() 
		{
			if (connection == null)
				return null;

			var q = connection.Table<T> ();
			return q;
		}
	}
}


