using CarConsoleSimulator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConsoleSimulator.Services
{
    public class PersonService : IPersonService
    {
        public Person Get()
        {
            using (var client = new HttpClient())
            {
                var jsonResult = client.GetStringAsync("https://randomuser.me/api/").Result;
                dynamic jsonObject = JsonConvert.DeserializeObject<dynamic>(jsonResult);

                var result = new Person();
                result.Title = jsonObject.results[0].name.title;
                result.FirstName = jsonObject.results[0].name.first;
                result.LastName = jsonObject.results[0].name.last;
                return result;
            }
        }
    }
}
