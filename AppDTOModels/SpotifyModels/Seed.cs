using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels.SpotifyModels
{
    public class Seed
    {
        public int initialPoolSize { get; set; }
        public int afterFilteringSize { get; set; }
        public int afterRelinkingSize { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }
}
