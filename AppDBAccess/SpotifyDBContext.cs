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

namespace AppDBAccess
{
    public class SpotifyDBContext
    {
        string clientId;
        string clientSecret;
        public SpotifyDBContext()
        {
            clientId = "7a45756d65a741c4bcb45c05844738e8";
            clientSecret = "b815f5b7a685493494948e7a677f3bcc";
        }
        public async Task<string> GetToken()
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

                DtoAccessToken token = JsonConvert.DeserializeObject<DtoAccessToken>(json);
                return token.access_token;
            }
        }
        public async Task<FullTrack> GetNewSongAsync(string id)
        {
            SpotifyClient spotify = new SpotifyClient(await GetToken());
            FullTrack temp = await spotify.Tracks.Get(id);
            return temp;
        }
        public async Task<string> GetArtistImageAsync(string id)
        {
            SpotifyClient spotify = new SpotifyClient(await GetToken());
            FullArtist temp = await spotify.Artists.Get(id);
            try
            {
                return temp.Images.LastOrDefault().Url;
            }
            catch
            {
                return "not_found.png";
            }
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
            TracksRequest temp = new TracksRequest(songIds);
            SpotifyClient spotify = new SpotifyClient(await GetToken());
            TracksResponse listOfSongs = await spotify.Tracks.GetSeveral(temp);
            List<FullTrack> returnList = listOfSongs.Tracks.ToList();
            return returnList;
        }
        //this methode will return a recommendation 
        public async Task<FullTrack> GetRecommendations()
        {
            SpotifyClient spotify = new SpotifyClient(await GetToken());
            SearchRequest request = new SearchRequest(SearchRequest.Types.Track, "DK rock");
            SearchResponse response = await spotify.Search.Item(request);
            FullTrack recommendedSong = response.Tracks.Items.First();
            return recommendedSong;
        }
        public async Task<Track[]> GetListOfRecommendations(int amount, string recommend)
        {
            //Få lavet så at den sorter på users settings chooses

            DBContext db = new DBContext();
            DtoSettings settings = await db.GetUsersSettingsAsync(1);
            string genre = settings.ChangeGenre;
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetToken());
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync($"https://api.spotify.com/v1/recommendations?limit={amount}&market=DK&seed_genres={genre.ToLower()}");
            }
            catch
            {
                return null;
            }
            if(response.IsSuccessStatusCode && response != null)
            {
                string json = await response.Content.ReadAsStringAsync();
                Rootobject temp = JsonConvert.DeserializeObject<Rootobject>(json);
                return temp.tracks;
            }
            return null;

        }
    }
}