﻿using AppDBAccess;
using AppDTOModels;
using AppDTOModels.SpotifyModels;
using AppModels;
using SpotifyAPI.Web;
using Swan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppRepository
{
    public class StartPageRepository : IStartPageRepository
    {
        DBContext db;
        SpotifyDBContext spotifyDB;
        public StartPageRepository()
        {
            db = new DBContext();
            spotifyDB = new SpotifyDBContext(db);
        }
        public async Task<FullTrack> GetSong(string songId)
        {
            return await spotifyDB.GetNewSongAsync(songId);
        }
        public async Task<bool> LikeSongAsync(WhiteList whiteList)
        {
            DtoWhiteList dtoWhiteList = new DtoWhiteList
            {
                UserID = whiteList.UserID,
                SongID = whiteList.SongID,
                SongArtistId = whiteList.SongArtistId
            };
            
            try
            {
                return await db.LikeSongAsync(dtoWhiteList);
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> SkipSongAsync(BlackList blackList)
        {
            DtoBlackList dtoBlackList = new DtoBlackList
            {
                UserID = blackList.UserID,
                SongID = blackList.SongID,
                SongArtistId = blackList.SongArtistId
            };
            try
            {
                return await db.SkipSongAsync(dtoBlackList);
            }
            catch
            {
                return false;
            }
        }
        public async Task<string> GetArtistImageAsync(string id)
        {
            return await spotifyDB.GetArtistImageAsync(id);
        }
        public async Task<DisplayedArtist> GetArtistAsync(string id)
        {
            FullArtist dtoArtist;
            try
            {
                dtoArtist = await spotifyDB.GetArtistAsync(id);
            }
            catch
            {
                return null;
            }
            DisplayedArtist artist = new DisplayedArtist
            {
                Id = dtoArtist.Id,
                Name = dtoArtist.Name,
                ImageUrl = dtoArtist.Images.FirstOrDefault().Url,
                LinkToSpotify = dtoArtist.Uri,
            };
            List<int> skipAndLike = await db.GetLikedAndSkipsForArtistAsync(artist.Id);
            if(skipAndLike != null)
            {
                if (skipAndLike.Count == 2)
                {
                    artist.AmountOfLikes = skipAndLike[0];
                    artist.AmountOfSkips = skipAndLike[1];
                }
                else
                {
                    artist.AmountOfLikes = 0;
                    artist.AmountOfSkips = 0;
                }
            }
            return artist;
        }
        public async Task<List<FullTrack>> GetListOfSongs(List<string> songIds)
        {
            try
            {
                return await spotifyDB.GetListOfSongs(songIds);
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<DisplayedSong>> GetListOfRecommendation(int id, int amount)
        {
            List<Track> listOfSongs = await spotifyDB.GetListOfRecommendations(id, amount);
            if (listOfSongs.Count > 0)
            {
                List<string> listOfArtistIds = new List<string>();
                for (int i = 0; i < listOfSongs.Count; i++)
                {
                    listOfArtistIds.Add(listOfSongs[i].artists.FirstOrDefault().id);
                }
                List<string> listOfArtistImageUrls = await spotifyDB.GetMultipleArtistImageAsync(listOfArtistIds);
                List<DisplayedSong> songList = new List<DisplayedSong>();
                for (int i = 0; i < listOfSongs.Count; i++)
                {
                    DisplayedSong song;
                    try
                    {
                        song = new DisplayedSong
                        {
                            Id = listOfSongs[i].id,
                            SongImage = listOfSongs[i].album.images.FirstOrDefault().url,
                            SongName = listOfSongs[i].name,
                            SongArtistImage = listOfArtistImageUrls[i],
                            AlbumName = listOfSongs[i].album.name,
                            ArtistName = listOfSongs[i].artists.FirstOrDefault().name,
                            ArtistId = listOfSongs[i].artists.FirstOrDefault().id,
                            IsPlayable = listOfSongs[i].is_playable,
                            PreviewUrl = listOfSongs[i].preview_url
                        };
                        songList.Add(song);
                    }
                    catch
                    {

                    }
                }
                if (songList.Count > 0)
                {
                    return songList;
                }
            }
            return null;
        }
    }
}
