using System;
using System.Collections.Generic;
using System.Text;

namespace UniversiadeAuditeste_Aula03.Model
{
    public class UsuarioRequest
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public int id { get; set; }

        public UsuarioRequest RetornarRequisicao()
        {
            Random random = new Random();
            int valorAleatorio = random.Next(0, 10000000);

            UsuarioRequest requisicao = new UsuarioRequest
            {
                name = "Chiquinho da Silva Sauro",
                gender = "male",
                email = $"chiquinho_{valorAleatorio}@auditeste.com.br",
                status = "active"
            };

            return requisicao;
        }
    }
}
