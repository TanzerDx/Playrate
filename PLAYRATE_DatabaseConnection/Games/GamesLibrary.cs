﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection.Games
{
    public class GamesLibrary : IGameRepository
    {
        private readonly string connectionString;

        public GamesLibrary(string con)
        {
            connectionString = con;
        }


        public List<GameDTO> GetAll(string console)
        {
            List<GameDTO> games = new List<GameDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console}", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    GameDTO gameDTO = CreateGameDTO(reader);
                    games.Add(gameDTO);
                }
                con.Close();
            }
            return games;
        }

        public GameDTO? GetGame(string name, string console)
        {
            GameDTO? gameDTO = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console} where Name = @Name",
                    con);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    gameDTO = CreateGameDTO(reader);
                }
                con.Close();
            }
            return gameDTO;
        }

        public List<GameDTO> GetByGenre(string genre, string console)
        {
            List<GameDTO> games = new List<GameDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console} where Genres = '{genre}'", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    GameDTO gameDTO = CreateGameDTO(reader);
                    games.Add(gameDTO);
                }
                con.Close();
            }
            return games;
        }

        public List<GameDTO> GetByMainFilter(string filter, string console)
        {
            List<GameDTO> games = new List<GameDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = null;

                SqlCommand GetSqlCommand()
                {
                    switch (filter)
                    {
                        case "Highest rating":
                            {
                                sqlCommand = new SqlCommand($"select * from dbo.{console} order by Rating DESC", con);
                                break;
                            }

                        case "Latest release":
                            {
                                sqlCommand = new SqlCommand($"select * from dbo.{console} order by Release_Date DESC", con);
                                break;
                            }

                        case "Most reviews":
                            {
                                //sqlCommand = new SqlCommand($"select * from dbo.{console} order by Rating DESC", con);
                                break;
                            }
                    }
                    return sqlCommand;
                }

                GetSqlCommand();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    GameDTO gameDTO = CreateGameDTO(reader);
                    games.Add(gameDTO);
                }
                con.Close();
            }
            return games;
        }

        public List<GameDTO> GetByKeyword(string keyword, string console)
        {
            List<GameDTO> games = new List<GameDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console} where Name LIKE '%{keyword}%'", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    GameDTO gameDTO = CreateGameDTO(reader);
                    games.Add(gameDTO);
                }
                con.Close();
            }
            return games;
        }

        private GameDTO CreateGameDTO(SqlDataReader reader)
        {
            return new GameDTO()
            {
                ID = reader.GetInt32(0),
                Name = reader.GetString(1),
                Developer = reader.GetString(2),
                Release_Date = reader.GetString(3),
                Genre = reader.GetString(4),
                Rating = reader.GetString(5),
                Description = reader.GetString(6),
                URL_Game = reader.GetString(7),
                URL_Page = reader.GetString(8)

            };
        }

        public void AddGame(string console, string name, string developer, string releaseDate, string genre, string rating, string desc, string urlGame, string urlPage)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand getMaxID = new SqlCommand($"SELECT COALESCE(MAX(ID), 0) FROM dbo.{console}", con);

                int currentMaxID = (int)getMaxID.ExecuteScalar();

                int newID = currentMaxID + 1;

                SqlCommand cmd = new SqlCommand($"INSERT into dbo.{console} VALUES (@ID, @Name, @Developer, @ReleaseDate, @Genre, @Rating, @Description, @URL_Game, @URL_Page)", con);


                cmd.Parameters.AddWithValue("@ID", newID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Developer", developer);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@Rating", rating);
                cmd.Parameters.AddWithValue("@Description", desc);
                cmd.Parameters.AddWithValue("@URL_Game", urlGame);
                cmd.Parameters.AddWithValue("@URL_Page", urlPage);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void RemoveGame(string console, string tbID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int id = Convert.ToInt32(tbID);

                con.Open();

                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.{console} WHERE ID='{id}'", con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
