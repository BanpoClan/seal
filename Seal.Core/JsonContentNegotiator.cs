using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;

namespace Seal.Core
{
    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter jsonMediaTypeFormatter;

        public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
        {
            jsonMediaTypeFormatter = formatter;
        }

        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            var result = new ContentNegotiationResult(jsonMediaTypeFormatter, new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }
}
