using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SoftTest.CalculadoraJuros.Domain;

namespace SoftTest.CalculadoraJuros.Data
{
    public class CalculadoraRepository : ICalculadoraRepository
    {
        private string _baseUrl = "https://softtesttaxajurosapi.azurewebsites.net";
        private string _endpoint = "/api/taxaJuros";        

        public async Task<double> ObterTaxaJuros()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync($"{_baseUrl + _endpoint}");                

                var result = JsonConvert.DeserializeObject<double>(await response.Content.ReadAsStringAsync());                

                return result;
            }
        }
    }    
}