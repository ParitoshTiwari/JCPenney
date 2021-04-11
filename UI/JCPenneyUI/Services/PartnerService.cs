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
        private string ErrorMessage;
        private PartnerModel partners;
        public PartnerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<PartnerModel>> GetPartners()
        {
            var a = await httpClient.GetFromJsonAsync<PartnerModel[]>("/Partners");
            return a;
        }

        public async Task<PartnerModel> AddPartners(string name, string email, string phone)
        {
            PartnerModel model = new PartnerModel();
            model.Name = name;
            model.Email = email;
            model.PhoneNum = phone;
            var resultData = await httpClient.PostAsJsonAsync<PartnerModel>("/Partners",model);
            if (!resultData.IsSuccessStatusCode)
            {
                ErrorMessage = resultData.ReasonPhrase;
            }
            partners = await resultData.Content.ReadFromJsonAsync<PartnerModel>();
            return partners;
        }

        public async Task<PartnerModel> EditPartners(string name, string email, string phone, string emailID)
        {
            PartnerModel model = new PartnerModel();
            model.Name = name;
            model.Email = email;
            model.PhoneNum = phone;

            var resultData = await httpClient.PutAsJsonAsync<PartnerModel>("/Partners", model);
            if (!resultData.IsSuccessStatusCode)
            {
                ErrorMessage = resultData.ReasonPhrase;
            }
            partners = await resultData.Content.ReadFromJsonAsync<PartnerModel>();
            return partners;
        }

        public async Task DeletePartner(string email)
        {
            var resultData = await httpClient.DeleteAsync("/Partners");
        }
    }
}
