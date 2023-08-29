using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class WhiteList
    {
        public int id { get; set; }
        public int userID { get; set; }
        public User user { get; set; }
        public int songID { get; set; }
        public List<Song> song { get; set; }
    }
}
