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

    [Route("api/[controller]")]
    public class BillingController : Controller
    {
        // Used to return a start of billing received
        [HttpGet("{billingStartReceivedAt}", Name = "StartBillingReceived")]
        public IActionResult GetById(DateTime billingStartReceivedAt)
        {
            return new ObjectResult(billingStartReceivedAt);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] StartBilling obj)
        {
            Console.WriteLine("PUT for start billing request received");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("{0}={1}", name, value);
            }
//            string response = String.Format("{\"StartBillingReceived\" : \"{0}\"", DateTime.Now);
            string response = "{\"StartBillingReceived\" : \"" + DateTime.Now.ToString() + "\"}";
            return Ok(response);
        }

    }
}
