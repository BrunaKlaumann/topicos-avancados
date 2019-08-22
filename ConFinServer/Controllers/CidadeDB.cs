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
        public static List<Cidade> GetCidade()
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
                    //Mais usado está descomentado
                    // string sigla = dr.GetString(0);
                    // string nome= dr.GetString(1);
                    int codigo = (int)dr["cid_codigo"];
                    string nome = (string)dr["nome"];
                    Cidade cidade = new Cidade();
                    cidade.cid_codigo = codigo;
                    cidade.nome = nome;
                    lista.Add(cidade);

                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao consultar Cidade." + erro.Message);
            }
            return lista;
        }
        public static bool SetIncuiCidade(Cidade cidade)
        {
            bool incluiu = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "insert into cidade(cid_codigo,nome) values(@codigo,@nome)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.cid_codigo;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }

            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro inclusão da cidade " + erro.Message);
            }
            return incluiu;
        }
        public static bool SetAlteraCidade(Cidade cidade)
        {
            bool alterou = false;
            try
            {
                NpgsqlConnection conexao = Conexao.GetConexao();
                string sql = "update cidade set nome=@nome where cid_codigo = @codigo";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.cid_codigo;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.nome;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao alterar Cidade" + erro.Message);

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
                cmd.Parameters.Add("@codigo", NpgsqlTypes.NpgsqlDbType.Varchar).Value = cidade.cid_codigo;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                Console.WriteLine("Erro ao excluir Cidade" + erro.Message);
            }
            return excluiu;
        }
    }
}
