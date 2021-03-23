using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalRealtor
{
    public static class HttpRequestMessage_Log
    {

        public static System.Net.Http.HttpRequestMessage Log(this System.Net.Http.HttpRequestMessage request)
        {
            //URL
            string urlString = request.RequestUri.AbsoluteUri;

            //Headers
            string headerString = "";
            foreach (var header in request.Headers)
            {
                headerString += $"{header.Key}:{string.Join(",", header.Value.ToArray())}\r";
            }

            //Body
            string bodyString = "";
            if (request.Method == System.Net.Http.HttpMethod.Post)
            {
                bodyString = request.Content.ReadAsStringAsync().Result;
            }

            Console.WriteLine($"\r# ##################################################\r\r# URL:\r{urlString}\r\r# METHOD:\r{request.Method.ToString()}\r\r# HEADERS:\r{headerString}\r\r# BODY:\r{bodyString}\r# ##################################################");

            return request;
        }


    }
}
