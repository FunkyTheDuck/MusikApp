using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class ArtistPayment
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public List<Artist>? Artist { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
