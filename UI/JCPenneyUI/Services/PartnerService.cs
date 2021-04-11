// PartnerService.cs/Users/paritoshmacbook/Projects/JCPenney/UI/JCPenneyUI/Services/Users/paritoshmacbook/Projects/JCPenney/UI/JCPenneyUI/Services/PartnerService.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/PartnerService
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using JCPenneyUI.Data;

namespace JCPenneyUI.Services
{
    public class PartnerService : IPartnerService
    {
        private readonly HttpClient httpClient;

        public PartnerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<PartnerModel>> GetPartners()
        {
            var a = await httpClient.GetFromJsonAsync<PartnerModel[]>("/Partners");
            return a;
        }

        public async Task<IEnumerable<PartnerModel>> AddPartners(PartnerModel model)
        {
            var resultData = await httpClient.PostAsJsonAsync<PartnerModel>("/Partners");
        }
    }
}
