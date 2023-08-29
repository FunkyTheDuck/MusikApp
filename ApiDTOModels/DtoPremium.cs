using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoPremium
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DtoUser user { get; set; }
        public DateTime transactionDay { get; set; }
        public DateTime nextTransactionDay { get; set; }
    }
}
