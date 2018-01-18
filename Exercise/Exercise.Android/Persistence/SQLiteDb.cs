using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Exercise.Droid.Persistence;
using Exercise.Persistence;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Exercise.Droid.Persistence
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