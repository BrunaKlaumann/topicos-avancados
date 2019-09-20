using ConFinClient.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ConFinClient.Controle
{
    public class EstadoServices
    {
        public static async Task<List<Estado>> GetEstados()
        {
            List<Estado> lista = new List<Estado>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44379/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);

            HttpResponseMessage respose = await client.GetAsync("estado");
            lista = JsonConvert.DeserializeObject<List<Estado>>(await respose.Content.ReadAsStringAsync());

            return lista;
        }

        public static async Task<string> PostEstado([FromBody] Estado estado)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44379/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);

            HttpResponseMessage respose = await client.PostAsJsonAsync("estado", estado);
            return respose.StatusCode.ToString();

        }
    }
}