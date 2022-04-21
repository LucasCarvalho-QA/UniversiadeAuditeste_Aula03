using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using UniversiadeAuditeste_Aula03.Controller;
using UniversiadeAuditeste_Aula03.Model;

namespace UniversiadeAuditeste_Aula03.Tests
{
    public class UsuarioBodyPayload
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string status { get; set; }
    }

    [TestFixture, Category("Usuário")]
    public class Usuario
    {
        
        UsuarioBodyPayload bodyRequest = new UsuarioBodyPayload();
        UsuarioRequest usuarioRequest = new UsuarioRequest();
        Executor executor = new Executor();
        CriarUsuario criarUsuario = new CriarUsuario();

        [TestCase(TestName = "Criar usuário - Sucesso")]
        public void CriarUsuario_Sucesso()
        {
            //Arrange - Os pré requisitos do teste            
            bodyRequest.email = "chiquinho1@auditeste.com.br";
            bodyRequest.name = "Chiquinho QA";
            bodyRequest.status = "active";
            bodyRequest.gender = "male";

            //Act - De fato vamos fazer nosso teste
            RestClient client = new RestClient("https://gorest.co.in/public/v2/users");
            client.Authenticator = new JwtAuthenticator("");
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(bodyRequest);
            
            IRestResponse response = client.Execute(request);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestCase(TestName = "Criar usuário - Com Sucesso - 2")]
        public void CriarUsuario_ComSucesso_2()
        {
            //Arrange - Os pré requisitos do teste
            UsuarioRequest bodyRequest = usuarioRequest.RetornarRequisicao();

            //Act - De fato vamos fazer nosso teste            
            IRestResponse response = executor.ExecutorApiRest(Method.POST, null,bodyRequest);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestCase(TestName = "Criar usuário - Com email existente")]
        public void CriarUsuario_ComEmailExistente()
        {
            //Arrange - Os pré requisitos do teste
            UsuarioRequest bodyRequest = usuarioRequest.RetornarRequisicao();

            //Act - De fato vamos fazer nosso teste            
            executor.ExecutorApiRest(Method.POST, null, bodyRequest);
            IRestResponse response = executor.ExecutorApiRest(Method.POST, null, bodyRequest);

            //Assert - Onde fazemos as nossas validações
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, response.StatusCode);
        }

        [TestCase(TestName = "Listar Usuario Especifico - Sucesso")]
        public void ListarUsuarios()
        {
            //Arrange            
            UsuarioRequest usuarioRecemCriado = criarUsuario.CriarUsuario_Sucesso();

            //Act
            IRestResponse response = executor.ExecutorApiRest(Method.GET, usuarioRecemCriado.id);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
