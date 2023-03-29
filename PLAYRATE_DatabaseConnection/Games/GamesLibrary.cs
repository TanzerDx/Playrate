using System;
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console}", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    GameDTO gameDTO = CreateGameDTO(reader);
                    games.Add(gameDTO);
                }
                connection.Close();
            }
            return games;
        }

        //public GameDTO? GetByGenre(string genre, string console)
        //{
        //    GameDTO? gameDTO = null;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console} where Genres = @genre",
        //            connection);
        //        sqlCommand.Parameters.AddWithValue("@genre", genre);
        //        SqlDataReader reader = sqlCommand.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            gameDTO = CreateGameDTO(reader);
        //        }
        //        connection.Close();
        //    }
        //    return gameDTO;
        //}

        public GameDTO? GetGame(string console, string name)
        {
            GameDTO? gameDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from dbo.{console} where  Name= '{name}' ",
                    connection);
                sqlCommand.Parameters.AddWithValue("@name", name);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    gameDTO = CreateGameDTO(reader);
                }
                connection.Close();
            }
            return gameDTO;

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
                URL_Page = reader.GetString(8),

            };
        }

        public void AddGame(string console, string name, string genre, string releaseDate, string developer, string rating, string desc, string urlGame, string urlPage)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand getMaxID = new SqlCommand($"SELECT COALESCE(MAX(ID), 0) FROM dbo.{console}", connection);

                int currentMaxID = (int)getMaxID.ExecuteScalar();

                int newID = currentMaxID + 1;

                SqlCommand cmd = new SqlCommand($"INSERT into dbo.{console} VALUES (@ID, @Name, @Genre, @ReleaseDate, @Developer, @Rating, @Description, @URL_Game, @URL_Page)", connection);


                cmd.Parameters.AddWithValue("@ID", newID);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@Developer", developer);
                cmd.Parameters.AddWithValue("@Rating", rating);
                cmd.Parameters.AddWithValue("@Description", desc);
                cmd.Parameters.AddWithValue("@URL_Game", urlGame);
                cmd.Parameters.AddWithValue("@URL_Page", urlPage);

                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void RemoveGame(string console, string tbID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int id = Convert.ToInt32(tbID);

                connection.Open();

                SqlCommand cmd = new SqlCommand($"DELETE FROM dbo.{console} WHERE ID='{id}'", connection);
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
