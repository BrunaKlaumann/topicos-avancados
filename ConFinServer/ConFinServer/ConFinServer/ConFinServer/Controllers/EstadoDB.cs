using ConFinServer.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Controllers
{
    public class EstadoDB
    {
        public static List<Estado> GetEstados()
        {
            List<Estado> lista = new List<Estado>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from estado";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr =  cmd.ExecuteReader();
                while (dr.Read())
                {
                    //Mais usado está descomentado
                    // string sigla = dr.GetString(0);
                    // string nome= dr.GetString(1);
                    string sigla = (string)dr["est_sigla"];
                    string nome = (string)dr["nome"];
                    Estado estado = new Estado();
                    estado.est_sigla = sigla;
                    estado.nome = nome;
                    lista.Add(estado);

                }
            }
            catch (NpgsqlException erro) 
            {
                Console.WriteLine("Erro ao consultar estados." + erro.Message);
            }
            return lista;
        }
        public static bool SetIncuiEstado(Estado estado)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into estado(est_sigla,nome) values(@sigla,@nome)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.est_sigla;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.nome;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }

            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro inclusão estado " + erro.Message);
            }
            return incluiu;
        }
        public static bool SetAlteraEstado(Estado estado)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update estado set nome=@nome where est_sigla = @sigla";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.est_sigla;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.nome;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                } 
            }
            catch(NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar estado" + erro.Message);

            }
            return alterou;
        }
        public static bool SetExcluiEstado(Estado estado)
        {
            bool excluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "delete from estado where est_sigla = @sigla";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = estado.est_sigla;
                int valor = cmd.ExecuteNonQuery();
                if(valor == 1)
                {
                    excluiu = true;
                }
            }catch(NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir estado" + erro.Message);
            }
            return excluiu;
        }
    }
}
