using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoSong
    {
        public int id { get; set; }
        public int artistId { get; set; }
        public DtoArtist artist { get; set; }
        [Required, MaxLength(100)]
        public string name { get; set; }
        [MaxLength(255)]
        public string albumImage { get; set; }
        [Required]
        public byte[] audioExample { get; set; }
        [MaxLength(100)]
        public List<string> genre { get; set; }
        public DtoWhiteList whiteList { get; set; }
        public DtoBlackList blackList { get; set; }
    }
}
