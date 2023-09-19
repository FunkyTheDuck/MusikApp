using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppModels
{
    public class DisplayedArtist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int AmountOfLikes { get; set; }
        public int AmountOfSkips { get; set; }
        public string ImageUrl { get; set; }
        public string LinkToSpotify { get; set; }
    }
}
