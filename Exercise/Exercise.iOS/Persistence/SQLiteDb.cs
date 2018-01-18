using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Exercise.iOS.Persistence;
using Exercise.Persistence;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Exercise.iOS.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db");

            return new SQLiteAsyncConnection(path);
        }
    }
}