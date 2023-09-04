using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels
{
    public class DtoAccessToken
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public long ExpirersIn { get; set; }
    }
}
