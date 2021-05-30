using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using CampeonatoAquiCampeao.Entity;
using System.Data.SqlClient;
using CampeonatoAquiCampeao.Interface;

namespace CampeonatoAquiCampeao.Repository
{
    public class PartidaRepository : BaseRepository , IPartidaRepository
    {
        
        public List<Partida> Listar()
        {
            string query = @"SELECT [Id]
                                   ,[IdVisitante]
                                   ,[IdMandante]
                                   ,[Data]
                                   ,[GolsVisitante]
                                   ,[GolsMandante]


                            FROM    [Partida]";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.Query<Partida>(query).ToList();

        }
        public void Inserir(Partida partida)
        {
            String query = @"INSERT INTO Partida
                               ([IdVisitante]
                              ,[IdMandante]
                              ,[Data]
                              ,[GolsVisitante]
                              ,[GolsMandante])
                           VALUES
                               (@IdVisitante
                              ,@IdMandante
                              ,@Data
                              ,@GolsVisitante
                              ,@GolsMandante)";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, partida);

        }
        public Partida Obter(int Id)
        {
            string query = @"SELECT [Id]
                                   ,[IdVisitante]
                                   ,[IdMandante]
                                   ,[Data]
                                   ,[GolsVisitante]
                                   ,[GolsMandante]
                               FROM [Partida]
                               WHERE [Id] = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.QueryFirstOrDefault<Partida>(query, new { Id });



        }
        public void Atualizar (Partida partida)
        {
            String query = @"UPDATE [Partida]
                             SET[IdMandante] = @IdMandante
                               ,[IdVisitante] = @IdVisitante
                               ,[Data] = @Data
                               ,[GolsMandante] = @GolsMandante
                               ,[GolsVisitante] = @GolsVisitante
                           WHERE[Id] = @Id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, partida);

        }
        public void Deletar(int Id)
        {
            String query = @"DELETE FROM Partida WHERE Id = @id";

            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            conn.Execute(query, new { Id });
        }
        public List<Partida> ListarClassificacao(int IdClube)
        {
            string query = @"SELECT
                                    [Id]
                                   ,[IdVisitante]
                                   ,[IdMandante]
                                   ,[Data]
                                   ,[GolsVisitante]
                                   ,[GolsMandante]      
                               FROM Partida
                              WHERE IdMandante = @IdClube
                                 OR IdVisitante = @IdClube";
            SqlConnection conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn.Query<Partida>(query, new { IdClube }).ToList();
        }
    }
}


