using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using cad_restapi.Models;
using System.ComponentModel;

namespace cad_restapi.Controllers
{

    public class SystemController : Controller
    {
        public class PortfolioResponse
        {
            public string message { get; set; }
            public Dictionary<string, string> portfolios { get; set; }
        }

        public class Rule
        {
            public string command { get; set; }
            public string businessRule { get; set; }
        }


        // GET api/system
        [Route("api/system")]
        [HttpGet]
        public string Get()
        {
            Console.WriteLine("In GET /api/system");
            var response = new PortfolioResponse();
            response.portfolios = new Dictionary<string, string>()
            {
                { "portfolioUPD", "[akka://demoSystem/user/demoSupervisor/PortfolioUPD#983089506]" },
                { "portfolioACE", "[akka://demoSystem/user/demoSupervisor/PortfolioACE#220375013]" },
                { "portfolioMGO", "[akka://demoSystem/user/demoSupervisor/PortfolioMGO#1590969739]" },
                { "portfolioDHY", "[akka://demoSystem/user/demoSupervisor/PortfolioDHY#1239442796]" },
                { "portfolioISR", "[akka://demoSystem/user/demoSupervisor/PortfolioISR#1050964355]" }
            };
            response.message = "5 portfolios started.";
            return JsonConvert.SerializeObject(response);
        }

        [Route("api/system/businessrules")]
        public string getRules()
        {
            Console.WriteLine("In GET /api/system/businessrules");
            Rule[] rules = new Rule[5];
            rules[0] = new Rule();
            rules[1] = new Rule();
            rules[2] = new Rule();
            rules[3] = new Rule();
            rules[4] = new Rule();
            rules[0].command = "BillingAssessment";
            rules[0].businessRule = "AnObligationMustBeActiveForBilling";
            rules[1].command = "BillingAssessment";
            rules[1].businessRule = "AccountBalanceMustNotBeNegative";
            rules[2].command = "BillingAssessment";
            rules[2].businessRule = "Rule2";
            rules[3].command = "BillingAssessment";
            rules[3].businessRule = "Rule3";
            rules[4].command = "BillingAssessment";
            rules[4].businessRule = "Rule4";

            return JsonConvert.SerializeObject(rules);
        }

        [Route("api/system/businessrules")]
        [HttpPost]
        public string postRules([FromBody] string body)
        {
            Console.WriteLine("POST received with value=" + body);
            return "Hi Jon";
        }

    }
}
