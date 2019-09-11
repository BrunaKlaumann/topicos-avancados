using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Controllers
{
    public class Conexao
    {
        public static NpgsqlConnection GetConexao()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=financeiro;");
                conexao.Open();
            } catch(NpgsqlException erro)
            {
                Console.WriteLine("Erro de conexão. " + erro.Message);                
            }
            return conexao;
        }

        public static void SetFechaConexao(NpgsqlConnection conexao)
        {
            if(conexao != null)
            {
                try
                {
                    conexao.Close();
                }catch(NpgsqlException erro)
                {
                    Console.WriteLine("Erro ao fechão conexão. " + erro.Message);
                }
            }
        }
    }
}
