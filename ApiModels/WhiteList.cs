using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class WhiteList
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public string SongID { get; set; }
    }
}
