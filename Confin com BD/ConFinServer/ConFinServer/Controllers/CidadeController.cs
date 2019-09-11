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
    public class CidadeController : ControllerBase
    {        
        /// <summary>
        /// Método para retornar as cidade cadastradas
        /// </summary>
        /// <returns>Retorna a lista de cidades</returns>
        [AcceptVerbs("GET")]
        //[Route("ConsultarCidades")]//Informação para adicionar uma subrota de acesso ao serviço
        public List<Cidade> GetCidades()
        {
            return CidadeDB.GetCidades();
        }

        /// <summary>
        /// Método que cadatra uma cidade nova
        /// </summary>
        /// <param name="cidade">Objeto com as informações da cidade</param>
        /// <returns>Informação, texto de retorno se cadastrou</returns>
        [AcceptVerbs("POST")]
        public string PostCidade(Cidade cidade)
        {
            bool incluiu = CidadeDB.SetIncluiCidade(cidade);
            if (incluiu)
            {
                return "Cidade incluída com sucesso!";
            }
            else
            {
                return "Erro, cidade não incluída!";
            }
        }

        /// <summary>
        /// Método que altera uma cidade
        /// </summary>
        /// <param name="cidade">Objeto com as informações da cidade</param>
        /// <returns>Informação, texto de retorno se alterou</returns>
        [AcceptVerbs("PUT")]
        public string PutEstado(Cidade cidade)
        {
            bool alterou = CidadeDB.SetAlteraCidade(cidade);
            if (alterou)
            {
                return "Cidade alterada com sucesso!";
            }
            else
            {
                return "Erro, cidade não alterada!";
            }
        }

        /// <summary>
        /// Método que exclui uma cidade
        /// </summary>
        /// <param name="cidade">Objeto com as informações do cidade</param>
        /// <returns>Informação, texto de retorno se exclui</returns>
        [AcceptVerbs("DELETE")]
        public string DeleteCidade(Cidade cidade)
        {
            bool excluiu = CidadeDB.SetExcluiCidade(cidade);
            if (excluiu)
            {
                return "Cidade excluída com sucesso!";
            }
            else
            {
                return "Erro, cidade não excluída!";
            }
        }
    }
}