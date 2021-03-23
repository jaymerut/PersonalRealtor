using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonalRealtor.Network.RealtorAPI.API
{
    public class RealtorClientHandler : HttpClientHandler
    {
        #region - Variables
        #endregion



        #region - Constructors

        #endregion



        #region - Private API
        #endregion



        #region - Public API
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            // Log
            request.Log();

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
        #endregion
    }
}
