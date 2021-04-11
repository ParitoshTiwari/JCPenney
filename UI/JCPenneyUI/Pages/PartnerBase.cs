// PartnerBase.cs/Users/paritoshmacbook/Projects/JCPenney/UI/JCPenneyUI/Pages/Users/paritoshmacbook/Projects/JCPenney/UI/JCPenneyUI/Pages/PartnerBase.csParitosh Tiwaritiwari.paritosh@outlook.comParitosh Tiwari 2021*/PartnerBase
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JCPenneyUI.Data;
using JCPenneyUI.Services;
using Microsoft.AspNetCore.Components;

namespace JCPenneyUI.Pages
{
    public class PartnerBase : ComponentBase
    {
        [Inject]
        public IPartnerService partnerService { get; set; }


        public bool IsClicked { get; set; }

        public IEnumerable<PartnerModel> partners { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsClicked = false;
        }

        public async void Create()
        {
            IsClicked = true;
            partners = (await partnerService.GetPartners()).ToList();
        }

        public async void AddPartner(PartnerModel model)
        {
            partners = ((IEnumerable<PartnerModel>)await partnerService.AddPartners(model.Name, model.Email, model.PhoneNum));
        }

        public async void EditPartner(PartnerModel model, string email)
        {
            partners = ((IEnumerable<PartnerModel>)await partnerService.EditPartners(model.Name, model.Email, model.PhoneNum, email));
        }

        public async void DeletePartner(string deletePartner)
        {
            partners = ((IEnumerable<PartnerModel>)partnerService.DeletePartner(deletePartner));
        }
    }
}
