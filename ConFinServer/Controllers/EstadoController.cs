using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConFinServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConFinServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        public static List<Estado> lista = new List<Estado>();
          
        [AcceptVerbs("GET")]
        public List<Estado> Get()
        {
            return EstadoDB.GetEstados();
        }


        [AcceptVerbs("POST")]
        public string PostEstado(Estado estado)
        {
            bool incluiu = EstadoDB.SetIncuiEstado(estado);
            if (incluiu)
            {
                return "Estado incluido com sucesso!";
            }
            else
            {
                return "Erro ao incluir estado!";
            }
        }

        [AcceptVerbs("PUT")]
        public string PutEstado(Estado estado)
        {
            bool alterou = EstadoDB.SetAlteraEstado(estado);
            if (alterou)
            {
                return "Estado alterado com sucesso: ";
            }
            else
            {
                return "Erro ao alterar estado ";
            }

            
        }

        [AcceptVerbs("DELETE")]
        public string DeleteEstado (Estado estado)
        {

            bool excluiu = EstadoDB.SetExcluiEstado(estado);
            if (excluiu)
            {
                return "Estado excluido com sucesso: ";
            }
            else
            {
                return "Erro ao excluir estado ";
            }
        }
    }
}