using System;
using System.Collections.Generic;
using System.Text;
using PersonalRealtor.Views.Pages.RealtorListings.UI;
using PersonalRealtor.Network.RealtorAPI.API;
using PersonalRealtor.Models;
using PersonalRealtor.Network.RealtorAPI.Models;
using System.Threading.Tasks;
using System.Net.Http;
using PersonalRealtor.Components.DataTemplateSelectors;
using PersonalRealtor.Network.RapidAPI.API;
using PersonalRealtor.Network.RapidAPI.Models;

namespace PersonalRealtor.Views.Pages.RealtorListings.Composer
{
    public static class RealtorListingsUIComposer
    {
        public static RealtorListingsPage MakeRealtorListingsUI()
        {
            List<AgentListingsRequest> requestList = new List<AgentListingsRequest>();

            foreach(Agent agent in RealtorSingleton.Instance.Agents)
            {
                requestList.Add(new AgentListingsRequest()
                {
                    FulfillmentId = RealtorSingleton.Instance.FulfillmentIds[0],
                    AgentId = agent.AgentId,
                    Id = agent.Id,
                    Type = "all"
                });
            }

            var dataTemplateSelector = new PropertyListingDataTemplateSelector();

            return new RealtorListingsPage(requestList, dataTemplateSelector);
        }

    }
}
