using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Models
{
    public class Conta
    {
        public int cnt_numero { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public float valor { get; set; }
        public string tipo { get; set; }
        public string situacao { get; set; }
        public int pes_codigo { get; set; }

    }
}
