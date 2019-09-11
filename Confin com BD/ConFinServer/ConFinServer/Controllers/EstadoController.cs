using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConFinServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    //Endereço de rota. Como vai ser chamado os recursos na URI
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        //Lista auxiliar para testar os métodos
        public static List<Estado> lista = new List<Estado>();

        /// <summary>
        /// Método para retornar os estados cadastrados
        /// </summary>
        /// <returns>Retorna a lista de estados</returns>
        [AcceptVerbs("GET")]
        //[Route("ConsultarEstados")]//Informação para adicionar uma subrota de acesso ao serviço
        public List<Estado> GetEstados()
        {
            return EstadoDB.GetEstados();
        }

        /// <summary>
        /// Método que cadatra um estado novo
        /// </summary>
        /// <param name="estado">Objeto com as informações do estado</param>
        /// <returns>Informação, texto de retorno se cadastrou</returns>
        [AcceptVerbs("POST")]
        public string PostEstado(Estado estado)
        {
            bool incluiu = EstadoDB.SetIncluiEstado(estado);
            if (incluiu)
            {
                return "Estado incluído com sucesso!";
            }
            else
            {
                return "Erro, estado não incluído!";
            }
            
        }

        /// <summary>
        /// Método que altera um estado
        /// </summary>
        /// <param name="estado">Objeto com as informações do estado</param>
        /// <returns>Informação, texto de retorno se alterou</returns>
        [AcceptVerbs("PUT")]
        public string PutEstado(Estado estado)
        {
            bool alterou = EstadoDB.SetAlteraEstado(estado);
            if (alterou)
            {
                return "Estado alterado com sucesso!";
            }
            else
            {
                return "Erro, estado não alterado!";
            }
            
        }

        /// <summary>
        /// Método que exclui um estado
        /// </summary>
        /// <param name="estado">Objeto com as informações do estado</param>
        /// <returns>Informação, texto de retorno se exclui</returns>
        [AcceptVerbs("DELETE")]
        public string DeleteEstado(Estado estado)
        {
            bool excluiu = EstadoDB.SetExcluiEstado(estado);
            if (excluiu)
            {
                return "Estado excluído com sucesso!";
            }
            else
            {
                return "Erro, estado não excluído!";
            }
            
        }
    }
}