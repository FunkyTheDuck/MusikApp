﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels.SpotifyModels
{
    public class UIAlbum
    {
        public string album_type { get; set; }
        public List<UIArtist> artists { get; set; }
        public UIExternal_Urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<UIImage> images { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public string release_date_precision { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
}
