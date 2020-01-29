using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GAP.MedicalAppointment.IntegrationTest.EntityFrameworkTest
{
    public class PatientRepositoryTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public PatientRepositoryTest() 
        {

            _server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task Register_Patient()
        {
            
            var body = "{\"documentId\":\"111222333\",\"name\":\"PRUEBAINTEGRACION\",\"lastName\":\"444555666\",\"phoneNumber\":\"777777\",\"email\":\"PRUEBA@JS.COM\",\"userName\":\"PRUEBAINTEGRACION\",\"password\":\"PRUEBAINTEGRACION\"}";
            var data = new StringContent(body, Encoding.UTF8, "application/json");
            var resp = await _client.PostAsync("api/Patient", data);

            Assert.IsTrue((int)resp.StatusCode == 200);
        }
    }
}
