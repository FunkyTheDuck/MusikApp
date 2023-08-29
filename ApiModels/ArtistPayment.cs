using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class ArtistPayment
    {
        public int id { get; set; }
        public int artistId { get; set; }
        public List<Artist> artist { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
