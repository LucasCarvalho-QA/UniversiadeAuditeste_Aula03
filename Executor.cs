using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using UniversiadeAuditeste_Aula03.Model;

namespace UniversiadeAuditeste_Aula03
{
    public class Executor
    {
        public IRestResponse ExecutorApiRest(Method metodo, int? id, object bodyRequest = null)
        {
            string token = "4c97e60b3df0585dec6c0c67b40167544635f7e6e796ddadea302f2ff3ea2c44";
            
            RestClient client = new RestClient("https://gorest.co.in/public/v2/users");
            client.Authenticator = new JwtAuthenticator(token);
            
            RestRequest request = new RestRequest(metodo);

            if (bodyRequest != null)
            {
                request.AddJsonBody(bodyRequest);
            }

            if (metodo == Method.GET)
            {
                client = new RestClient($"https://gorest.co.in/public/v2/users/{id}");
            }

            return client.Execute(request);
        }
    }
}
