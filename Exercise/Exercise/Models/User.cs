using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Models
{
    public class Rootobject
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        [JsonProperty("data")]
        public List<User> Users { get; set; }
    }

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }
}
