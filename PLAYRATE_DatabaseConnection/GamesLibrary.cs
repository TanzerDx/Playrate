using BusinessLogic;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_DatabaseConnection
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

        public int? GetGameID(string console, string name)
        {
            int? gameID = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT ID FROM dbo.{console} WHERE Name = '{name}'", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    gameID = reader.GetInt32(0);
                }
                con.Close();
            }
            return gameID;
        }

        public List<GameDTO> Filter(string? keyword, string? mainFilter, string? genre, string console)
        {
            List<GameDTO> games = new List<GameDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = null;
                
                string? order = null;

                string GetOrderBy()
                {
                    switch (mainFilter)
                    {
                        case "Highest rating":
                            {
                                order = "Rating DESC";
                                break;
                            }

                        case "Latest release":
                            {
                                order = "Release_Date DESC";
                                break;
                            }

                        case "Most reviews":
                            {
                                order = "Reviews DESC";
                                break;
                            }
                    }
                
                    return order;
                }

                SqlCommand GetSqlCommand()
                {
                    GetOrderBy();

                    switch (keyword != "", mainFilter != "", genre != "")
                    {
                        case (true, false, false):
                            sqlCommand = new SqlCommand($"select * from dbo.{console} where Name LIKE '%{keyword}%'", con);
                            break;
                        
                        case (false, true, false):
                            sqlCommand = new SqlCommand($"select * from dbo.{console} order by {order}", con);
                            break;

                        case (false, false, true):
                            sqlCommand = new SqlCommand($"select * from dbo.{console} where Genres = '{genre}'", con);
                            break;

                        case (true, true, false):
                            sqlCommand = new SqlCommand($"select * from dbo.{console} where Name LIKE '%{keyword}%' ORDER BY {order}", con);
                            break;

                        case (true, false, true):
                            sqlCommand = new SqlCommand($"select * from dbo.{console} where Name LIKE '%{keyword}%' AND Genres = '{genre}'", con);
                            break;

                        case (false, true, true):
                            sqlCommand = new SqlCommand($"select * from dbo.{console} where Genres = '{genre}' ORDER BY {order}", con);
                            break;

                        case (true, true, true):
                            sqlCommand = new SqlCommand($"select * from dbo.{console} where NAME LIKE '%{keyword}%' AND Genres = '{genre}' ORDER BY {order}", con);
                            break;

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

        public List<GameDTO> GetRecommendations(string username)
        {
            List<GameDTO> games = new List<GameDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand($"SELECT TOP 1 Console_ID FROM dbo.Reviews WHERE Username = '{username}' AND Rating > 4 GROUP BY Console_ID ORDER BY COUNT(*) DESC;", con);
                int consoleID = (int)cmd1.ExecuteScalar();

                SqlCommand cmd2 = new SqlCommand($"SELECT Model FROM dbo.Consoles WHERE ID = '{consoleID}';", con);
                string console = cmd2.ExecuteScalar().ToString();

                SqlCommand sqlCommandMain = new SqlCommand($"SELECT g.ID, g.Name, g.Developer, g.Release_Date, g.Genres, g.Rating, g.Description, g.URL_Game, g.URL_Page, g.Console_ID FROM dbo.Consoles c JOIN dbo.{console} g ON g.Console_ID = c.ID WHERE g.Rating BETWEEN 4 AND 5 AND g.Genres IN (SELECT Genres FROM dbo.{console} WHERE ID = g.ID)  AND NOT EXISTS (SELECT 1 FROM Reviews r WHERE r.Username = '{username}' AND r.Game_ID = g.ID AND r.Console_ID = c.ID);", con);

                SqlDataReader reader = sqlCommandMain.ExecuteReader();

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
                Release_Date = reader.GetDateTime(3),
                Genre = reader.GetString(4),
                Rating = reader.GetDouble(5),
                Description = reader.GetString(6),
                URL_Game = reader.GetString(7),
                URL_Page = reader.GetString(8),
                Console_ID = reader.GetInt32(9)

            };
        }

        public void AddGame(string console, string name, string developer, DateTime releaseDate, string genre, string desc, string urlGame, string urlPage, int? consoleID)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"INSERT into dbo.{console} VALUES (@Name, @Developer, @ReleaseDate, @Genre, @Rating, @Description, @URL_Game, @URL_Page, @Console_ID, @Reviews)", con);

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Developer", developer);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@Rating", 0);
                cmd.Parameters.AddWithValue("@Description", desc);
                cmd.Parameters.AddWithValue("@URL_Game", urlGame);
                cmd.Parameters.AddWithValue("@URL_Page", urlPage);
                cmd.Parameters.AddWithValue("@Console_ID", consoleID);
                cmd.Parameters.AddWithValue("@Reviews", 0);

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

        public void SetRating(int? consoleID, int? gameID, string console)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE dbo.{console} SET Rating = (SELECT AVG(Rating)  FROM dbo.Reviews  WHERE Console_ID = '{consoleID}' AND Game_ID = '{gameID}') WHERE ID = '{gameID}'", con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void CalculateNumberOfReviews(int? consoleID, int? gameID, string console)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"UPDATE dbo.{console} SET Reviews = (SELECT COUNT(*) FROM dbo.Reviews WHERE Console_ID = '{consoleID}' AND Game_ID = '{gameID}') WHERE ID = '{gameID}'", con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
