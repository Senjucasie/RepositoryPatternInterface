using PersonReader.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace PersonReader.Service
{
    public class ServiceReader : IPersonReader
    {
        private WebClient client = new WebClient();
        private string baseUri = "http://localhost:9874";
        JsonSerializerOptions option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        

        public IEnumerable<Person> GetPeople()
        {
            string address = $"{baseUri}/people";
            string reply = client.DownloadString(address);
            return JsonSerializer.Deserialize<IEnumerable<Person>>(reply, option);
        }

        public Person GetPerson(int id)
        {
            string address = $"{baseUri}/people/{id}";
            string reply = client.DownloadString(address);
            return JsonSerializer.Deserialize<Person>(reply, option);
        }
    }
}
