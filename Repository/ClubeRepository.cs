using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using CampeonatoAquiCampeao.Entity;
using System.Text;
using System.Data.SqlClient;
using CampeonatoAquiCampeao.Interface;

namespace CampeonatoAquiCampeao.Repository
{
    public class ClubeRepository : BaseRepository ,  IClubeRepository
    {
        
        public List<Clube> Listar()
        {
            string query = @"SELECT [Id]
                               ,[Nome]
                               ,[NomeEstadio]
                               ,[AnoFundacao]
                               ,[Cidade]
                           FROM [Clube]";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.Query<Clube>(query).ToList();

        }
        public void Inserir(Clube Clube)
        {
            String query = @"INSERT INTO Clube
                               ([Nome]
                              ,[NomeEstadio]
                              ,[AnoFundacao]
                              ,[Cidade])
                           VALUES
                               (@Nome
                              ,@NomeEstadio
                              ,@AnoFundacao
                              ,@Cidade)";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, Clube);
        }

        public Clube Obter(int Id)
        {
            string query = @"SELECT [Id]
                                    ,[Nome]
                                    ,[NomeEstadio]
                                    ,[AnoFundacao]
                                    ,[Cidade]
                                FROM [Clube]
                               WHERE [Id] = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Clube>(query, new { Id });
        }

        public Clube ObterPorNome(string Nome)
        {
            string query = @"SELECT [Id]
                                ,[Nome]
                                ,[NomeEstadio]
                                ,[AnoFundacao]
                                ,[Cidade]
                            FROM [dbo].[Clube]
                            WHERE Nome = @Nome";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Clube>(query, new { Nome });
        }

        public void Atualizar(Clube clube)
        {
            String query = @"UPDATE [Clube]
                               SET[Nome] = @Nome
                                 ,[NomeEstadio] = @NomeEstadio
                                 ,[AnoFundacao] = @AnoFundacao
                                 ,[Cidade] = @Cidade
                            WHERE [Id] = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, clube);
        }
        public void Deletar(int Id)
        {
            String query = @"DELETE FROM Clube WHERE Id = @id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, new { Id });
        }

    }
}
