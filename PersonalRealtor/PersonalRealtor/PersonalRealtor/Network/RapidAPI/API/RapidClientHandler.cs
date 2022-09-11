using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalRealtor.Network.RapidAPI.API
{
    public class RapidClientHandler : HttpClientHandler
    {
        #region - Variables
        private const string apiKey = "4a10242a63msh939c8fbd5f14a8cp19e8d8jsn6bd2993356d5";
        private const string apiHost = "realtor.p.rapidapi.com";
        #endregion



        #region - Constructors

        #endregion



        #region - Private API
        #endregion



        #region - Public API
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // X-RapidAPI-Key
            {
                var key = "x-rapidapi-key";
                request.Headers.Add(key, $"{apiKey}");
            }

            // X-RapidAPI-Host
            {
                var key = "x-rapidapi-host";
                request.Headers.Add(key, $"{apiHost}");
            }

            // UseQueryString
            {
                var key = "useQueryString";
                request.Headers.Add(key, "true");
            }

            // Log
            request.Log();

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
