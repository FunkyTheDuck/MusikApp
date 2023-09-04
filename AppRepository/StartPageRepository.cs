﻿using AppDBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
    public class StartPageRepository
    {
        DBContext db;
        SpotifyDBContext spotifyDB;
        public StartPageRepository()
        {
            db = new DBContext();
            spotifyDB = new SpotifyDBContext();
        }
        public async Task<bool> LikeSongAsync(int userId, int songId)
        {
            await spotifyDB.GetNewSong("DK", 3);
            return true;
        }
        public async Task<bool> SkipSongAsync(int userId, int songId)
        {
            return true;
        }
    }
}
