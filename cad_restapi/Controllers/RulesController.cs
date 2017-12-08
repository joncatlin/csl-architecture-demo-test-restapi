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
        public string[] Commands { get; set; }

        // Ordering of rules is implied by the position in the array
        public Rule[] RuleArray { get; set; }
    }

    [Route("api/[controller]")]
    public class RulesController : Controller
    {
        // GET api/rules
        [HttpGet]
        public string Get()
        {
            Rules rules = new Rules();
            rules.Commands = new string[] { "Assess", "Bill" };

            Rule rule1 = new Rule();
            rule1.ID = 234;
            rule1.RuleDescription = "Rule description 1";
            rule1.NumParameters = 2;
            rule1.Parameters = new string[] { "default for param1", "default for param2" };

            Rule rule2 = new Rule();
            rule2.ID = 89;
            rule2.RuleDescription = "Rule description 2";
            rule2.NumParameters = 3;
            rule2.Parameters = new string[3] { "R2 param 1", "R2 param2", "R3 param3" };

            Rule rule3 = new Rule();
            rule2.ID = 278;
            rule2.RuleDescription = "Rule description 3";
            rule2.NumParameters = 0;
            rule2.Parameters = new string[0];

            rules.RuleArray = new Rule[3] { rule1, rule2, rule3 };

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
