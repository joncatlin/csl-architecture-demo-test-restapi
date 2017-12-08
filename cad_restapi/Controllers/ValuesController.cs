using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace cad_restapi.Controllers
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string Balance { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LastPaymentDate { get; set; }
    }

    public class Messages
    {
        public string Message { get; set; }
    }

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            Account account = new Account
            {
                AccountNumber = "12345",
                Balance = "$300.43",
                FirstName = "Jon",
                LastName = "Catlin",
                LastPaymentDate = "11/1/2017"};

//            return new string[] { "value1", "value2", "Hi Jon" };
            return JsonConvert.SerializeObject(account);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            if (id == 1234)
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
                    Message = "Account " + id + " not found. Please enter a valid account number."
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
