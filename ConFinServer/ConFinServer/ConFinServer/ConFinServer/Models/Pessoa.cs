using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Models
{
    public class Pessoa
    {
        public int  pes_codigo { get; set; }
        public string nome { get; set; }
        public int idade { get; set; }
        public string email { get; set; }
        public int cid_codigo { get; set; }
    }
}
