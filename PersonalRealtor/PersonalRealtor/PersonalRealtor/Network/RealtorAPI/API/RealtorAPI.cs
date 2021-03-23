using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PersonalRealtor.Network.RealtorAPI.Models;

namespace PersonalRealtor.Network.RealtorAPI.API
{
    public class RealtorAPI
    {
        private IRealtorAPI _API;
        private IRealtorAPI API
        {
            get
            {
                if (_API == null)
                {

                    var client = new HttpClient(new RealtorClientHandler()
                    {
                        ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true,
                    })
                    {
                        BaseAddress = new Uri("https://www.realtor.com")
                    };


                    _API = RestService.For<IRealtorAPI>(client, new RefitSettings()
                    {
                        ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings()
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

        public async Task<RealtorListingsResponse> RealtorListings(RealtorListingsRequest request)
        {
            return await this.API.RealtorListings(request);
        }
    }
}
