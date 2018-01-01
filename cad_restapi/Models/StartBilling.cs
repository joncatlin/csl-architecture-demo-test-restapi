using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cad_restapi.Models
{
    public class StartBilling
    {
        public string PMCaseId { get; set; }
        public string PMUserId { get; set; }
        public long PortfolioId { get; set; }
        public int Command { get; set; }
    }
}
