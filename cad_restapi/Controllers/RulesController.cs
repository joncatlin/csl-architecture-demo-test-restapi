using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace cad_restapi.Controllers
{
    public class Rule
    {
        public int ID { get; set; }
        public string RuleDescription { get; set; }
        public int NumParameters { get; set; }
        public string[] Parameters { get; set; }
    }

    public class Rules
    {
        public Dictionary<string, string> Portfolios { get; set; }

        public Dictionary<string, string> Commands { get; set; }

        // Ordering of rules is implied by the position in the array
        public Dictionary<int, Dictionary<string, string>> RuleArray { get; set; }
    }

    [Route("api/[controller]")]
    public class RulesController : Controller
    {
        // GET api/rules
        [HttpGet]
        public string Get()
        {
            Rules rules = new Rules();
            rules.Commands = new Dictionary<string, string>()
            {
                { "10", "Assess" },
                { "11", "Bill" }
            };

            rules.Portfolios = new Dictionary<string, string>()
            {
                { "1", "Cayman Islands" },
                { "2", "Tokyo" },
                { "3", "London Basin" },
                { "4", "Bornmouth" },
                { "5", "Isle of Sky" },
                { "6", "Sun Dance" },
                { "7", "Fiji" },
                { "10", "Fiji2" },
                { "11", "Wild Wilderness" },
                { "13", "Tame Wilderness" },
                { "15", "Boring" },
                { "16", "Fantasic and a great place to go" },
                { "17", "Somewhere Else Land" }
            };

            Dictionary<string, string> rule1 = new Dictionary<string, string>()
            {
                {"Id", "234"}, {"Name", "Rule1" }, {"Description", "This is the description for rule 1" },
                {"NumParameters", "2" }, {"Param1", "Default value of param 1"}, {"Param2", "Default value of param 2"}
            };

            Dictionary<string, string> rule2 = new Dictionary<string, string>()
            {
                {"Id", "432"}, {"Name", "Rule2" }, {"Description", "This is the description for rule 2" },
                {"NumParameters", "1" }, {"Param1", "Default value of param 1"}
            };

            Dictionary<string, string> rule3 = new Dictionary<string, string>()
            {
                {"Id", "887"}, {"Name", "Rule3" }, {"Description", "This is the description for rule 3" },
                {"NumParameters", "3" }, {"Param1", "Default value of param 1"}, {"Param2", "Default value of param 2"}, {"Param3", "Default value of param 3"}
            };

            rules.RuleArray = new Dictionary<int, Dictionary<string, string>>()
            {
                { 0, rule1 },
                { 1, rule2 },
                { 2, rule3 }
            };

            return JsonConvert.SerializeObject(rules);
        }

        // GET api/rules/5
        [HttpGet("{portfolioid}")]
        public string Get(int portfolioID)
        {
            if (portfolioID == 1234)
            {
                return JsonConvert.SerializeObject(new Account
                {
                    AccountNumber = "12345",
                    Balance = "$300.43",
                    FirstName = "Jon",
                    LastName = "Catlin",
                    LastPaymentDate = "11/1/2017"
                });
            }
            else
            {
                return JsonConvert.SerializeObject(new Messages
                {
                    Message = "Account " + portfolioID + " not found. Please enter a valid account number."
                });
            }
        }

    // POST api/values
    [HttpPost]
        public void Post([FromBody]string value)
        {
            Console.WriteLine("PUT received with value=" + value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            Console.WriteLine("PUT received with id=" + id + ", value=" + value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
