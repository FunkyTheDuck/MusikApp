using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class Song
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string AlbumImage { get; set; }
        public byte[] AudioExample { get; set; }
        [MaxLength(100)]
        public List<string> Genre { get; set; }
        public WhiteList WhiteList { get; set; }
        public BlackList BlackList { get; set; }
    }
}
