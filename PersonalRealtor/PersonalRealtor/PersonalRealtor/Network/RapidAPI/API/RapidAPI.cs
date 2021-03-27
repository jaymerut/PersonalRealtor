using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Network.RapidAPI.Models;

namespace PersonalRealtor.Network.RapidAPI.API
{
    public class RapidAPI
    {
        private IRapidAPI _API;
        private IRapidAPI API
        {
            get
            {
                if (_API == null)
                {

                    var client = new HttpClient(new RapidClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true,
                    })
                    {
                        BaseAddress = new Uri("https://realtor.p.rapidapi.com")
                    };


                    _API = RestService.For<IRapidAPI>(client, new RefitSettings()
                    {
                        ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings()
                        {
                            NullValueHandling = NullValueHandling.Include,
                            MissingMemberHandling = MissingMemberHandling.Ignore,
                            Converters = { new StringEnumConverter() }
                        }),
                    });

                }
                return _API;
            }
        }

        public async Task<AgentsListResponse> AgentsList(String postalCode, String name)
        {
            return await this.API.AgentsList(postalCode, name);
        }
        public async Task<PropertyDetailsResponse> GetPropertyDetails(String propertyId)
        {
            return await this.API.GetPropertyDetails(propertyId);
        }
    }
}
