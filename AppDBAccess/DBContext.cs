using AppDTOModels;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AppDBAccess
{
    public class DBContext
    {
        HttpClient client;

        public DBContext() 
        {
            client = new HttpClient();
        }
        public async Task<List<DtoArtistPayment>> GetArtistPayment()
        {
            HttpResponseMessage response = null;
            response = await client.GetAsync($"https://localhost:44325/api/ArtistPayment");
            string json = await response.Content.ReadAsStringAsync();
            List<DtoArtistPayment> artistPaymentsList = JsonConvert.DeserializeObject<List<DtoArtistPayment>>(json);
            return artistPaymentsList;
        }
        public async Task<DtoArtistPayment> GetArtistPayment(int id)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync($"https://localhost:44325/api/ArtistPayment/{id}");
                string json = await response.Content.ReadAsStringAsync();
                DtoArtistPayment artistPayment = JsonConvert.DeserializeObject<DtoArtistPayment>(json);
                return artistPayment;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateArtistPayment(DtoArtistPayment artistPayment)
        {
            string json = JsonConvert.SerializeObject(artistPayment);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44325/api/ArtistPayment", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateArtistPayment(DtoArtistPayment artistPayment)
        {
            string json = JsonConvert.SerializeObject(artistPayment);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string uri = Path.Combine("https://localhost:44325/api/ArtistPayment", $"{artistPayment.Id}");
            var response = await client.PutAsync(uri, content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteArtistPayment(int id)
        {
            string uri = Path.Combine("https://localhost:44325/api/ArtistPayment", $"{id}");
            var response = await client.DeleteAsync(uri);  
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteSong(int id)
        {
            string uri = Path.Combine("https://localhost:44325/api/Songs", $"{id}");
            var response = await client.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }
        public async Task<List<DtoUser>> GetUser()
        {
            HttpResponseMessage response = null;
            response = await client.GetAsync($"https://localhost:44325/api/User");
            string json = await response.Content.ReadAsStringAsync();
            List<DtoUser> users = JsonConvert.DeserializeObject<List<DtoUser>>(json);
            return users;
        }
        public async Task<DtoArtistPayment> GetUser(int id)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync($"https://localhost:44325/api/User/{id}");
                string json = await response.Content.ReadAsStringAsync();
                DtoArtistPayment artistPayment = JsonConvert.DeserializeObject<DtoArtistPayment>(json);
                return artistPayment;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateUser(DtoUser user)
        {
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44325/api/User", content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> UpdateUser(DtoUser user)
        {
            string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string uri = Path.Combine("https://localhost:44325/api/ArtistPayment", $"{user.Id}");
            var response = await client.PutAsync(uri, content);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> DeleteUser(int id)
        {
            string uri = Path.Combine("https://localhost:44325/api/User", $"{id}");
            var response = await client.DeleteAsync(uri);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> LikeSongAsync(DtoWhiteList whiteList)
        {
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(whiteList);
            }
            catch
            {
                return false;
            }
            if(!string.IsNullOrEmpty(json))
            {
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync("https://localhost:7147/api/WhiteList", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
        public async Task<bool> SkipSongAsync(DtoBlackList blackList)
        {
            string json = string.Empty;
            try
            {
                json = JsonConvert.SerializeObject(blackList);
            }
            catch
            {
                return false;
            }
            if (!string.IsNullOrEmpty(json))
            {
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync("https://localhost:7147/api/BlackList", content);
                }
                catch
                {
                    return false;
                }
                return response.IsSuccessStatusCode;
            }
            return false;
        }
    }
}