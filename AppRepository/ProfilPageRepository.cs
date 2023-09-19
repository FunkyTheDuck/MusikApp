using AppDBAccess;
using AppDTOModels.SpotifyModels;
using AppModels;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository
{
    public class ProfilPageRepository : IProfilPageRepository
    {
        DBContext db { get; set; }
        SpotifyDBContext spotifyDB { get; set; }
        public ProfilPageRepository()
        {
            db = new DBContext();
            spotifyDB = new SpotifyDBContext();
        }
        public async Task<List<DisplayedSong>> GetAllLikedSongs(int userId, int startPos)
        {
            List<string> likedSongsId;
            try
            {
                likedSongsId = await db.GetAllLikedSongsId(userId);
            }
            catch
            {
                return null;
            }
            if (likedSongsId.Count > 0)
            {
                if(likedSongsId.Count > 49)
                {
                    int temp = 0;
                    for (int i = startPos; i < likedSongsId.Count; i++)
                    {
                        temp++;
                        likedSongsId.RemoveAt(i);
                    }
                }
                List<FullTrack> likedSongs = await spotifyDB.GetListOfSongs(likedSongsId);
                List<string> listOfArtistIds = new List<string>();
                for (int i = 0; i < likedSongs.Count; i++)
                {
                    try
                    {
                        listOfArtistIds.Add(likedSongs[i].Artists.FirstOrDefault().Id);
                    }
                    catch
                    {

                    }
                }
                List<string> listOfArtistImageUrls = await spotifyDB.GetMultipleArtistImageAsync(listOfArtistIds);
                List<DisplayedSong> songList = new List<DisplayedSong>();
                for (int i = 0; i < likedSongs.Count; i++)
                {
                    DisplayedSong song;
                    try
                    {
                        song = new DisplayedSong
                        {
                            Id = likedSongs[i].Id,
                            SongImage = likedSongs[i].Album.Images.FirstOrDefault().Url,
                            SongArtistImage = listOfArtistImageUrls[i],
                            SongName = likedSongs[i].Name,
                            AlbumName = likedSongs[i].Album.Name,
                            ArtistName = likedSongs[i].Artists.FirstOrDefault().Name,
                            IsPlayable = likedSongs[i].IsPlayable,
                            PreviewUrl = likedSongs[i].PreviewUrl
                        };
                        songList.Add(song);
                    }
                    catch
                    {

                    }
                }
                return songList;
            }
            return null;
        }
    }
}
