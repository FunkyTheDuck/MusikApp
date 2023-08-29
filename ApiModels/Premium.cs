using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Premium
    {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public DateTime transactionDay { get; set; }
        public DateTime nextTransactionDay { get; set; }
    }
}
