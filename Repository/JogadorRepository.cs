using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using CampeonatoAquiCampeao.Entity;
using System.Data.SqlClient;
using CampeonatoAquiCampeao.Interface;

namespace CampeonatoAquiCampeao.Repository
{
    public class JogadorRepository : IJogadorRepository

    {
        public string _connectionString = "Server=DANILO\\SQLEXPRESS; Database=AquiCampeao;Trusted_Connection=True;";

        public List<Jogador> Listar()
        {
            string query = @"SELECT [Id]
                                   ,[Nome]
                                   ,[Posicao]
                                   ,[IdClube]
                                   ,[PeBom]
                            FROM    [Jogador]";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.Query<Jogador>(query).ToList();

        }
        public void Inserir(Jogador jogador)
        {
            String query = @"INSERT INTO Jogador
                               ([Nome]
                              ,[Posicao]
                              ,[IdClube]
                              ,[PeBom])
                           VALUES
                               (@Nome
                              ,@Posicao
                              ,@IdClube
                              ,@PeBom)";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, jogador);

        }

        public Jogador Obter(int Id)
        {
            string query = @"SELECT [Id]
                                   ,[Nome]
                                   ,[Posicao]
                                   ,[IdClube]
                                   ,[PeBom]
                               FROM [Jogador]
                               WHERE [Id] = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Jogador>(query, new { Id });

           

        }

        public void Atualizar (Jogador jogador)
        {
            String query = @"UPDATE [Jogador]
                               SET[Nome] = @Nome
                                 ,[Posicao] = @Posicao
                                 ,[IdClube] = @IdClube
                                 ,[PeBom] = @PeBom
                            WHERE [Id] = @Id";
                               
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, jogador);
        }

        public void Deletar (int Id)
        {
            String query = @"DELETE FROM Jogador WHERE Id = @id";
            
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query,new { Id });
        }




    }
}
    

