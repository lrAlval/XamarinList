using Exercise.Models;
using Exercise.Persistence;
using Exercise.Utils;
using Newtonsoft.Json;
using Plugin.Connectivity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Exercise.Data
{
    public class UserService
    {
        private HttpClient _client;
        private SQLiteAsyncConnection _connection;

        public UserService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://reqres.in/api/");
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        public async Task<List<User>> GetUsers()
        {
            var users = new List<User>();
            var rootObject = new Rootobject();

            await _connection.CreateTableAsync<User>();

            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _client.GetAsync("users");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    rootObject = JsonConvert.DeserializeObject<Rootobject>(content);
                    users = rootObject.Users;
                    var rows = await SyncApiDb(users);
                }
            }
            else
            {
                users = await _connection.Table<User>().ToListAsync();
            }

            return users;
        }


        private async Task<int> SyncApiDb(List<User> usersService)
        {
            var usersDb = await _connection.Table<User>().ToListAsync();
            var newList = usersService.Exclude(usersDb, db => db.Id);
            var rowsffected = await _connection.InsertAllAsync(usersService);
            return rowsffected;
        }

    }
}
