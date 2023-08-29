using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels
{
    public class DtoSong
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public DtoArtist Artist { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string AlbumImage { get; set; }
        [Required]
        public byte[] AudioExample { get; set; }
        [MaxLength(100)]
        public List<string> Genre { get; set; }
        public DtoWhiteList WhiteList { get; set; }
        public DtoBlackList BlackList { get; set; }
    }
}
