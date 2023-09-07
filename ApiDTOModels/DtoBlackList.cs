using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoBlackList
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public List<DtoUser>? User { get; set; }
        public string SongID { get; set; }
        public List<DtoSong>? Songs { get; set; }
    }
}
