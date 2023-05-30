using FluentResults;
using PLAYRATE_ClassLibrary.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLAYRATE_ClassLibrary.Consoles
{
    public class ConsoleService : IConsoleService
    {
        private const string _connectionString = "Data Source=mssqlstud.fhict.local;Persist Security Info=True;User ID = dbi499630; Password=Jvm5cNGGkr";
        private readonly IConsoleRepository _consolesLibrary;

        public ConsoleService(IConsoleRepository _consolesLibrary)
        {
            this._consolesLibrary = _consolesLibrary;
        }

        public Result<List<Console>> GetAll()
        {
            try
            {
                var consoles = _consolesLibrary.GetAll().Select(dto => dto.ToConsole()).ToList();
                return consoles;
            }
			catch (Exception exception)
			{
				return Result.Fail(new Error("Unable to get all consoles!").CausedBy(exception));
			}
}

        public Result<List<string>> GetConsoleByName()
        {
            try
            { 
                var consoles = _consolesLibrary.GetConsoleByName();
                return consoles;
            }
			catch (Exception exception)
			{
                return Result.Fail(new Error("Unable to get console by name!").CausedBy(exception));
            }           
        }

        public Result<Console> GetConsole(string name)
        {
            try
            { 
            var consoleDTO = _consolesLibrary.GetConsole(name);
            return consoleDTO.Value.ToConsole();
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to get console!").CausedBy(exception));
            }
        }

		public Result<int?> GetConsoleID(string console)
		{
            try
            { 
			    int? consoleID = _consolesLibrary.GetConsoleID(console);
                return consoleID;
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Unable to get console ID!").CausedBy(exception));
            }
        }

		public void AddConsole(string type, string model, string manufacturer, DateTime releaseDate, string urlConsole, string controllerType, string chatPlatform)
        {
            try
            { 
                //validation
                _consolesLibrary.AddConsole(type,model, manufacturer, releaseDate, urlConsole, controllerType, chatPlatform);
            }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable to add console!").CausedBy(exception));
            }
        }

        public void RemoveConsole(string console)
        {
            try
            {
                _consolesLibrary.RemoveConsole(console);
            }
            catch (Exception exception)
            {
                Result.Fail(new Error("Unable to remove console!").CausedBy(exception));
            }
        }

    }
}
