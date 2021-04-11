using Modelos;
using System.Net.Http;
using System.Threading.Tasks;
using ExtensionMethods;

namespace Integrations
{
    public class ViaCepIntegration
    {
        public async static Task<Endereco> GetEndereco(string CEP)
        {
            var HttpClient = new HttpClient();
            HttpResponseMessage Resposta = await HttpClient.GetAsync($"https://viacep.com.br/ws/{CEP}/json/");
            Resposta.EnsureSuccessStatusCode();

            EnderecoViaCep Endereco = await Resposta.Content.ReadAsAsync<EnderecoViaCep>();

            return Endereco.ToEndereco();
        }
    }
}