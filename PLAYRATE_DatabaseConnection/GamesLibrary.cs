using BusinessLogic;
using FluentResults;
using PLAYRATE_ClassLibrary;
using PLAYRATE_ClassLibrary.Consoles;
using PLAYRATE_ClassLibrary.Games;
using PLAYRATE_DatabaseConnection.FilterStrategy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

                IFilterStrategy filterStrategy = null;

                if (keyword != "" && mainFilter == "" && genre == "")
                {
                    filterStrategy = new FilterBy_Keyword_Strategy();
                }
                else if (keyword == "" && mainFilter != "" && genre == "")
                {
                    filterStrategy = new FilterBy_MainFilter_Strategy();
                }
                else if (keyword == "" && mainFilter == "" && genre != "")
                {
                    filterStrategy = new FilterBy_Genre_Strategy();
                }
                else if (keyword != "" && mainFilter != "" && genre == "")
                {
                    filterStrategy = new FilterBy_KeywordAndMainFilter_Strategy();
                }
                else if (keyword != "" && mainFilter == "" && genre != "")
                {
                    filterStrategy = new FilterBy_KeywordAndGenre_Strategy();
                }
                else if (keyword == "" && mainFilter != "" && genre != "")
                {
                    filterStrategy = new FilterBy_MainFilterAndGenre_Strategy();
                }
                else if (keyword != "" && mainFilter != "" && genre != "")
                {
                    filterStrategy = new FilterBy_All_Strategy();
                }


                if (filterStrategy != null)
                {
                    SqlCommand sqlCommand = filterStrategy.ApplyFilter(con, keyword, mainFilter, genre, console);

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        GameDTO gameDTO = CreateGameDTO(reader);
                        games.Add(gameDTO);
                    }
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

                SqlCommand cmd = new SqlCommand($"SELECT DISTINCT Console_ID FROM dbo.Reviews WHERE Username = '{username}' AND Rating BETWEEN 4 AND 5;", con);
                SqlDataReader consoleReader = cmd.ExecuteReader();

                List<int> consoleIDs = new List<int>();

                while (consoleReader.Read())
                {
                    int consoleID = consoleReader.GetInt32(0);
                    consoleIDs.Add(consoleID);
                }

                consoleReader.Close();

                foreach (int consoleID in consoleIDs)
                {
                    SqlCommand cmd2 = new SqlCommand($"SELECT Model FROM dbo.Consoles WHERE ID = '{consoleID}';", con);
                    string console = cmd2.ExecuteScalar().ToString();

                    SqlCommand sqlCommandMain = new SqlCommand($"SELECT g.* FROM dbo.Consoles c JOIN dbo.{console} g ON g.Console_ID = c.ID " +
                        $"WHERE g.Rating BETWEEN 4 AND 5 AND g.Genres IN (SELECT Genres FROM dbo.{console} " +
                        $"WHERE ID IN (SELECT Game_ID FROM Reviews WHERE Username = '{username}' AND Rating BETWEEN 4 AND 5)) AND NOT EXISTS " +
                        $"(SELECT 1 FROM Reviews r2 WHERE r2.Username = '{username}' AND r2.Game_ID = g.ID AND r2.Console_ID = c.ID);", con);

                    using (SqlDataReader reader = sqlCommandMain.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GameDTO gameDTO = CreateGameDTO(reader);
                            games.Add(gameDTO);
                        }
                    }
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
