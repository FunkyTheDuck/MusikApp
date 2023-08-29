using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels
{
    public class DtoPremium
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DtoUser User { get; set; }
        public DateTime TransactionDay { get; set; }
        public DateTime NextTransactionDay { get; set; }
    }
}
