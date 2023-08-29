using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoArtistPayment
    {
        public int id { get; set; }
        public int artistId { get; set; }
        public List<DtoArtist> artist { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
