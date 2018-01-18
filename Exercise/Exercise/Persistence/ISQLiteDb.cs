using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
