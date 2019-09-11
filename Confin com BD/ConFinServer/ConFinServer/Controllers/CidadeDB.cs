using ConFinServer.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConFinServer.Controllers
{
    public class CidadeDB
    {
        public static List<Cidade> GetCidades()
        {
            List<Cidade> lista = new List<Cidade>();
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "select * from cidade";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int codigo = int.Parse(dr["cid_codigo"].ToString());
                    string sigla = (string)dr["est_sigla"];
                    string nome = (string)dr["nome"];
                    Cidade cidade = new Cidade();
                    cidade.cid_codigo = codigo;
                    cidade.est_sigla = sigla;
                    cidade.nome = nome;
                    lista.Add(cidade);
                }
                dr.Close();
                Conexao.SetFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro de sql. " + erro.Message);
            }
            return lista;
        }

        public static bool SetIncluiCidade(Cidade cidade)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into cidade(cid_codigo,est_sigla,nome) values(@codigo,@sigla,@nome)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = cidade.cid_codigo;
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.est_sigla;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }
                Conexao.SetFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro de inclusão. " + erro.Message);
            }
            return incluiu;
        }

        public static bool SetAlteraCidade(Cidade cidade)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update cidade set nome = @nome, est_sigla = @sigla where cid_codigo = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = cidade.cid_codigo;
                cmd.Parameters.Add("@sigla", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.est_sigla;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
                Conexao.SetFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro de alteração. " + erro.Message);
            }
            return alterou;
        }

        public static bool SetExcluiCidade(Cidade cidade)
        {
            bool excluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "delete from cidade where cid_codigo = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Integer).Value = cidade.cid_codigo;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
                Conexao.SetFechaConexao(conexao);
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro de exclusão. " + erro.Message);
            }
            return excluiu;
        }
    }
}
