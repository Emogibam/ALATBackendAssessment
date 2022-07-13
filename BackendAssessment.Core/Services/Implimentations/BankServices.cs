﻿using BackendAssessment.Core.Services.Interfaces;
using BackendAssessment.Core.Utilities;
using BackendAssessment.Infrastructure.DTOs.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendAssessment.Core.Services.Implimentations
{
    public class BankServices : IBankServices
    {
        private readonly IOptions<AlatApiConfiguration> _configuration;
        HttpClientHandler _clientHandler = new HttpClientHandler();

        public BankServices(IOptions<AlatApiConfiguration> configuration)
        {
            _configuration = configuration;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, SslPolicyErrors) =>
            {
                return true;
            };
        }

        public async Task<ApiResponse<ListBanksDTO>> GetbankRequest()
        {
            var client = new RestClient("https://wema-alatdev-apimgt.developer.azure-api.net/api-details#api=alat-tech-test-api");

            var reponse = client.Execute<ListBanksDTO>(new RestRequest());

            //var client = new HttpClient();

            //var resultConfig = _configuration.Value;
            //// RequestMessage headers
            //var request = new HttpRequestMessage
            //{
            //    RequestUri = new Uri("https://wema-alatdev-apimgt.azure-api.net/alat-test/api/Shared/GetAllBanks"),
            //    Method = HttpMethod.Get,
            //    Headers =
            //    {
            //        { "Ocp-Apim-Subscription-Key", "7e9831430436453d84e13097385e5afa" }
            //    },
            //};

            //using var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //if (response.IsSuccessStatusCode)
            //{
            //    var res = await response.Content.ReadAsStringAsync();
            //    var serializer = new JsonSerializer();
            //    using var stringReader = new StringReader(res);
            //    using (var jsonReader = new JsonTextReader(stringReader))
            //    {
            //        jsonReader.SupportMultipleContent = true;
            //        ListBanksDTO result = serializer.Deserialize<ListBanksDTO>(jsonReader);
            //        return new ApiResponse<ListBanksDTO>((int)response.StatusCode, "success", "")
            //        {
            //            Data = result
            //        };
            //    };
            //}
            //throw new Exception("Server Error");


            //ListBanksDTO listOfBanks = new();
            //using (var httpClient = new HttpClient(_clientHandler))
            //{
            //    using (var response = await httpClient.GetAsync("https://wema-alatdev-apimgt.developer.azure-api.net/api-details#api=alat-tech-test-api"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();

            //        listOfBanks = JsonConvert.DeserializeObject<ListBanksDTO>(apiResponse);
            //    }
            //}

            return new ApiResponse<ListBanksDTO>((int)HttpStatusCode.OK, "success", "")
            {
                Data = (ListBanksDTO)reponse.Data
            };
        }
    }
}
