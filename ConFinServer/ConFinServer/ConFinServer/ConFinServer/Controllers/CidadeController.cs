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
    public class CidadeController : ControllerBase
    {
        public static List<Cidade> lista = new List<Cidade>();

        [AcceptVerbs("GET")]
        public List<Cidade> GetCidade()
        {
            return lista;
        }

        [AcceptVerbs("POST")]
        public string PostCidade(Cidade cidade)
        {
            lista.Add(cidade);
            return "Cidade incluído com Sucesso!";
        }
        [AcceptVerbs("PUT")]
        public string PutCidade(Cidade cidade)
        {
            lista.Where(l => l.cid_codigo == cidade.cid_codigo)
                .Select(o => {
                    o.nome = cidade.nome;
                    o.est_sigla = cidade.est_sigla;
                    return o;
                })
                .ToList();
            return "Cidade alterada com Sucesso!";
        }

        [AcceptVerbs("DELETE")]
        public string DeleteCidade(Cidade cidade)
        {
            Cidade auxcidade = lista.Where(l => l.cid_codigo == cidade.cid_codigo)
                    .Select(o => o)
                    .First();
            lista.Remove(auxcidade);
            return "Cidade excluida com sucesso!";
        }

    }
}