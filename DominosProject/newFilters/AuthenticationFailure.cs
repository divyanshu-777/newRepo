using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DominosProject.FilterService
{
    public class AuthenciationFailure : IHttpActionResult
    {

        #region "Variable"

        public string reasonPharse = string.Empty;

        #endregion

        #region "Property"

        /// <summary>
        /// Get and Set HttpRequst Message
        /// </summary>
        public HttpRequestMessage Request { get; set; }

        #endregion

        #region "Constructor"

        public AuthenciationFailure(string reasonePharse, HttpRequestMessage Request)
        {

            this.reasonPharse = reasonePharse;
            this.Request = Request;

        }

        #endregion

        #region "Public method"

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.ReasonPhrase = reasonPharse;
            response.RequestMessage = Request;
            return response;
        }

        #endregion
    }
}