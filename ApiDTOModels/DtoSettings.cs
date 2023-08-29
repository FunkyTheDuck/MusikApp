using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDTOModels
{
    public class DtoSettings
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DtoUser user { get; set; }
        [MaxLength(255)]
        public string changeGenre { get; set; }
        public int howNewTheMusicIs { get; set; }
        public int howManyNotifications { get; set; }
    }
}
