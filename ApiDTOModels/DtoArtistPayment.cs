using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoArtistPayment
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public List<DtoArtist> Artist { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
