using AppDTOModels;
using AppDTOModels.SpotifyModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using AppModels;
using System.Reflection.PortableExecutable;
using Xamarin.Essentials;
using static System.Net.WebRequestMethods;
using System.Collections.ObjectModel;
using System.Collections.Immutable;

namespace AppDBAccess
{
    public class SpotifyDBContext
    {
        HttpClient httpClient;
        string clientId;
        string clientSecret;
        DBContext db;
        DtoAccessToken token;
        DateTime expiredTime;
        public SpotifyDBContext(DBContext db)
        {
            this.db = db;
            httpClient = new HttpClient();
            clientId = "7a45756d65a741c4bcb45c05844738e8";
            clientSecret = "b815f5b7a685493494948e7a677f3bcc";
        }
        public async Task GetToken()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://accounts.spotify.com/api/");
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "token");

                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    {"grant_type", "client_credentials"}
                });

                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();

                token = JsonConvert.DeserializeObject<DtoAccessToken>(json);
                expiredTime = DateTime.Now.AddSeconds(token.expires_in);
            }
        }
        public async Task<FullTrack> GetNewSongAsync(string id)
        {
            if (expiredTime >= DateTime.Now.AddMinutes(-5) || token == null)
            {
                await GetToken();
            }
            SpotifyClient spotify = new SpotifyClient(token.access_token);
            FullTrack temp = await spotify.Tracks.Get(id);
            return temp;
        }
        public async Task<string> GetArtistImageAsync(string id)
        {
            if (expiredTime >= DateTime.Now.AddMinutes(-5) || token == null)
            {
                await GetToken();
            }
            SpotifyClient spotify = new SpotifyClient(token.access_token);
            FullArtist temp = await spotify.Artists.Get(id);

            try
            {
                if (temp.Images != null)
                {
                    return temp.Images.LastOrDefault().Url;
                }
            }
            catch
            {
                return "not_found.png";
            }
            return "not_found.png";
        }
        public async Task<List<string>> GetMultipleArtistImageAsync(List<string> ids)
        {
            if(ids.Count > 49)
            {
                return null;
            }
            if (expiredTime >= DateTime.Now.AddMinutes(-5) || token == null)
            {
                await GetToken();
            }
            SpotifyClient spotify = new SpotifyClient(token.access_token);
            ArtistsRequest listOfIds = new ArtistsRequest(ids);
            ArtistsResponse artistResponse = await spotify.Artists.GetSeveral(listOfIds);
            List<FullArtist> listOfArtist = artistResponse.Artists.ToList();
            List<string> listOfImageUrls = new List<string>();
            foreach (FullArtist artist in listOfArtist)
            {
                try
                {
                    listOfImageUrls.Add(artist.Images.LastOrDefault().Url);
                }
                catch
                {
                    listOfImageUrls.Add("not_found.png");
                }
            }
            return listOfImageUrls;
        }
        public async Task<FullArtist> GetArtistAsync(string artistId)
        {
            if (expiredTime >= DateTime.Now.AddMinutes(-5) || token == null)
            {
                await GetToken();
            }
            SpotifyClient spotify = new SpotifyClient(token.access_token);
            FullArtist artist = await spotify.Artists.Get(artistId);
            return artist;
        }
        public async Task<List<Genre>> GetAllGenresAsync()
        {
            List<Genre> GenreList = new();
            List<string> genres = new List<string>()

            {
            "acoustic", "afrobeat", "alt-rock", "alternative", "ambient", "anime", "black-metal", "bluegrass", "blues", "bossanova", "brazil", "breakbeat", "british",
            "cantopop", "chicago-house", "children", "chill", "classical", "club", "comedy", "country", "dance", "dancehall", "death-metal", "deep-house", "detroit-techno",
            "disco", "disney", "drum-and-bass", "dub", "dubstep", "edm", "electro", "electronic", "emo", "folk", "forro", "french", "funk", "garage", "german", "gospel", "goth",
            "grindcore", "groove", "grunge", "guitar", "happy", "hard-rock", "hardcore", "hardstyle", "heavy-metal", "hip-hop", "holidays", "honky-tonk", "house", "idm", "indian",
            "indie", "indie-pop", "industrial", "iranian", "j-dance", "j-idol", "j-pop", "j-rock", "jazz", "k-pop", "kids", "latin", "latino", "malay", "mandopop", "metal", "metal-misc",
            "metalcore", "minimal-techno", "movies", "mpb", "new-age", "new-release", "opera", "pagode", "party", "philippines-opm", "piano", "pop", "pop-film", "post-dubstep", "power-pop",
            "progressive-house", "psych-rock", "punk", "punk-rock", "r-n-b", "rainy-day", "reggae", "reggaeton", "road-trip", "rock", "rock-n-roll", "rockabilly", "romance", "sad",
            "salsa", "samba", "sertanejo", "show-tunes", "singer-songwriter", "ska", "sleep", "songwriter", "soul", "soundtracks", "spanish", "study", "summer", "swedish", "synth-pop",
            "tango", "techno", "trance", "trip-hop", "turkish", "work-out", "world-music"
            };
            foreach (var item in genres)
            {
                Genre genre = new Genre()
                {
                    Name = item
                };
                GenreList.Add(genre);
            }

            return GenreList;
        }
        public async Task<List<FullTrack>> GetListOfSongs(List<string> songIds)
        {
            if (expiredTime >= DateTime.Now.AddMinutes(-5) || token == null)
            {
                await GetToken();
            }
            if (songIds.Count > 49)
            {
                return null;
            }
            SpotifyClient spotify = new SpotifyClient(token.access_token);
            TracksRequest temp = new TracksRequest(songIds);
            TracksResponse listOfSongs = await spotify.Tracks.GetSeveral(temp);
            List<FullTrack> returnList = listOfSongs.Tracks.ToList();
            return returnList;
        }
        public async Task<List<Track>> GetListOfRecommendations(int id, int amount)
        {
            if (expiredTime >= DateTime.Now.AddMinutes(-5) || token == null)
            {
                await GetToken();
            }
            DtoSettings settings = await db.GetUsersSettingsAsync(id);
            string uri = $"https://api.spotify.com/v1/recommendations?limit={amount}";
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        if (!string.IsNullOrEmpty(settings.ChangeGenre))
                        {
                            uri += $"&seed_genres={settings.ChangeGenre.ToLower()}";
                        }
                        break;
                    case 1:
                        if (settings.Danceability != 0)
                        {
                            uri += $"&target_danceability={settings.Danceability}";
                        }
                        break;
                    case 2:
                        if (settings.Energy != 0)
                        {
                            uri += $"&target_energy={settings.Energy}";
                        }
                        break;
                    case 3:
                        if (settings.Popularity != 0)
                        {
                            uri += $"&target_popularity={settings.Popularity}";
                        }
                        break;
                    default:

                        break;
                }
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.token_type, token.access_token);
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync(uri);
            }
            catch
            {
                return null;
            }
            if (response.IsSuccessStatusCode && response != null)
            {
                string json = await response.Content.ReadAsStringAsync();
                Rootobject temp = JsonConvert.DeserializeObject<Rootobject>(json);

                List<string> listOfLikedSongs = await db.GetAllLikedSongsId(id);

                List<string> whiteListMatch = new List<string>();
                for (int i = 0; i < temp.tracks.Length; i++)
                {
                    whiteListMatch = listOfLikedSongs.Where(x => x == temp.tracks[i].id).ToList();
                }
                if (whiteListMatch.Count > 0)
                {
                    List<Track> tracks = temp.tracks.ToList();
                    for (int j = 0; j < whiteListMatch.Count; j++)
                    {
                        Track track = tracks.FirstOrDefault(match => match.id == whiteListMatch[j]);
                        if(track != null)
                        {
                            tracks.Remove(track);
                        }
                    }
                    return tracks;
                }
                return temp.tracks.ToList();
            }
            return null;
        }
    }
}