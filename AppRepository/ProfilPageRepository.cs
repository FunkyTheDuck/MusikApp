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
                List<DisplayedSong> songList = new List<DisplayedSong>();
                foreach (FullTrack track in likedSongs)
                {
                    DisplayedSong song;
                    try
                    {
                        song = new DisplayedSong
                        {
                            Id = track.Id,
                            SongImage = track.Album.Images.FirstOrDefault().Url,
                            SongArtistImage = await spotifyDB.GetArtistImageAsync(track.Artists.FirstOrDefault().Id),
                            SongName = track.Name,
                            AlbumName = track.Album.Name,
                            ArtistName = track.Artists.FirstOrDefault().Name,
                            IsPlayable = track.IsPlayable,
                            PreviewUrl = track.PreviewUrl
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
