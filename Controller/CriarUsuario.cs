using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using UniversiadeAuditeste_Aula03.Model;

namespace UniversiadeAuditeste_Aula03.Controller
{
    public class CriarUsuario
    {
        UsuarioRequest usuarioRequest = new UsuarioRequest();
        Executor executor = new Executor();

        public UsuarioRequest CriarUsuario_Sucesso()
        {
            UsuarioRequest requisicao = usuarioRequest.RetornarRequisicao();

            IRestResponse response = executor.ExecutorApiRest(Method.POST, null, requisicao);

            return JsonConvert.DeserializeObject<UsuarioRequest>(response.Content);
        }
    }
}
