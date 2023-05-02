﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using PLAYRATE_ClassLibrary;
using System.Text;
using System.Threading.Tasks;
using PLAYRATE_ClassLibrary.Consoles;
using System.Reflection;

namespace PLAYRATE_DatabaseConnection
{
    public class ConsoleLibrary : IConsoleRepository
    {
        private readonly string connectionString;

        public ConsoleLibrary(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ConsoleDTO> GetAll()
        {
            List<ConsoleDTO> consoles = new List<ConsoleDTO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from dbo.Consoles", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    ConsoleDTO consoleDTO = CreateConsoleDTO(reader);
                    consoles.Add(consoleDTO);
                }
                con.Close();
            }
            return consoles;
        }

        public ConsoleDTO? GetConsole(string model)
        {
            ConsoleDTO? consoleDTO = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from dbo.Consoles where Model=@Model",
                    con);
                sqlCommand.Parameters.AddWithValue("@Model", model);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    consoleDTO = CreateConsoleDTO(reader);
                }
                con.Close();
            }
            return consoleDTO;
        }

        public int? GetConsoleID(string console)
        {
            int? consoleID = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT ID FROM dbo.Consoles WHERE Model = '{console}'", con);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    consoleID = reader.GetInt32(0);
                }
                con.Close();
            }
            return consoleID;
        }


        private ConsoleDTO CreateConsoleDTO(SqlDataReader reader)
        {
            return new ConsoleDTO()
            {
                ID = reader.GetInt32(0),
                Model = reader.GetString(1),
                Manufacturer = reader.GetString(2),
                Release_Date = reader.GetString(3),
                URL_Console = reader.GetString(4),
                Controller_Type = reader.GetString(5),
                Chat_Platform = reader.GetString(6)

            };
        }

        private ConsoleDTO CreateConsoleDTO2(SqlDataReader reader)
        {
            return new ConsoleDTO()
            {
                Model = reader.GetString(0),
            };
        }

        public void AddConsole(string type, string model, string manufacturer, string releaseDate, string urlConsole, string controllerType, string chatPlatform)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();


                SqlCommand cmd = new SqlCommand($"CREATE TABLE dbo.{type + model} (ID int IDENTITY(1,1) PRIMARY KEY, Name varchar(50), Developer varchar(50), Release_Date varchar(20), Genres varchar(50), Rating varchar(20), Description varchar(5000), URL_Game varchar(MAX), URL_Page varchar(MAX));", con);

                SqlCommand cmd2 = new SqlCommand($"INSERT INTO dbo.Consoles VALUES (@Model, @Manufacturer, @Release_Date, @URL_Console, @Controller_Type, @Chat_Platform);", con);

                cmd2.Parameters.AddWithValue("@Model", type + model);
                cmd2.Parameters.AddWithValue("@Manufacturer", manufacturer);
                cmd2.Parameters.AddWithValue("@Release_Date", releaseDate);
                cmd2.Parameters.AddWithValue("@URL_Console", urlConsole);
                cmd2.Parameters.AddWithValue("@Controller_Type", controllerType);
                cmd2.Parameters.AddWithValue("@Chat_Platform", chatPlatform);

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                con.Close();
            }
        }

        public void RemoveConsole(string console)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand($"DROP TABLE dbo.{console}", con);
                SqlCommand cmd2 = new SqlCommand($"DELETE FROM dbo.Consoles WHERE Model='{console}'", con);

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}