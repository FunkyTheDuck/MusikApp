﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDTOModels.SpotifyModels
{
    public class Track
    {
        public Album album { get; set; }
        public Artist1[] artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public bool _explicit { get; set; }
        public External_Ids external_ids { get; set; }
        public External_Urls2 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public Linked_From linked_from { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
}
