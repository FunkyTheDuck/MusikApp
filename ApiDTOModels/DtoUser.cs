using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoUser
    {
        public int id { get; set; }
        public string? profilPicture { get; set; }
        [Required, MaxLength(100)]
        public string name { get; set; }
        [Required, MaxLength(100)]
        public string lastName { get; set; }
        [Required, MaxLength(255)]
        public string userName { get; set; }
        [Required, MaxLength(50)]
        public string mail { get; set; }
        public bool isPremium { get; set; }
        public bool isArtist { get; set; }
        public DtoWhiteList whiteList { get; set; }
        public DtoBlackList blackList { get; set; }
        public DtoSettings settings { get; set; }
        public DtoPremium premium { get; set; }
        public DtoArtist artist { get; set; }
    }
}
