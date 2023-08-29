using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Song
    {
        public int id { get; set; }
        public int artistId { get; set; }
        public Artist artist { get; set; }
        public string name { get; set; }
        public string albumImage { get; set; }
        public byte[] audioExample { get; set; }
        public List<string> genre { get; set; }
        public WhiteList whiteList { get; set; }
        public BlackList blackList { get; set; }
    }
}
