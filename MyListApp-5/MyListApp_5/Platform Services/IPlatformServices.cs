//
// Copyright (c), 2017. Object Training Pty Ltd. All rights reserved.
// Written by Tim Hastings.
//

using System;
using SQLite;
namespace MyListApp
{
	public interface IPlatformServices
	{
		SQLiteConnection GetConnection(String dbName);
		bool DatabaseExists(string dbname);
		bool DeleteDatabase(string dbname);

        // Web Services
        bool IsServerAvailable(String url);
        bool Login(String url, String resource, String userName, String password);
        bool GetList<T>(String url, String resource, String userName, String password);
    }
}
