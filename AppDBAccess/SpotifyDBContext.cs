﻿using AppDTOModels;
using AppDTOModels.SpotifyModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
                return token.AccessToken;
            }
        }
        public async Task<RootObject> GetNewSong(string countryCode, int limit)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri($"https://api.spotify.com/v1/");
                client.DefaultRequestHeaders.Add("Accept", "application/.json");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetToken());

                //returnere status kode 400 bad request
                HttpResponseMessage response = await client.GetAsync($"browse/new-releases?country={countryCode}&limit={limit}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    RootObject temp = JsonConvert.DeserializeObject<RootObject>(json);
                    return temp;
                }
                return null;
            }
        }







        public async Task<DtoAccessToken> GetOneSong()
        {
            HttpResponseMessage response;
            try
            {
                //response = await client.GetAsync($"https://accounts.spotify.com/api/token");
            }
            catch
            {
                response = null;
            }
            return null;
        }
    }
}