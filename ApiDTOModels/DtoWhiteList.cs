using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoWhiteList
    {
        public int id { get; set; }
        public int userID { get; set; }
        public DtoUser user { get; set; }
        public int songID { get; set; }
        public List<DtoSong> song { get; set; }
    }
}
