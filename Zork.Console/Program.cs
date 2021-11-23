using System.IO;
using Newtonsoft.Json;

namespace Zork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string defaultGameFilename = "Zork.json";
            string gameFilename = (args.Length > 0 ? args[(int)CommandLineArguments.GameFilename] : defaultGameFilename);

            Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(gameFilename));

            ConsoleInputService input = new ConsoleInputService();
            ConsoleOutputService output = new ConsoleOutputService();

            output.WriteLine(string.IsNullOrWhiteSpace(game.WelcomeMessage) ? "Welcome to Zork!" : game.WelcomeMessage);
            game.Start(input, output);

            while (game.IsRunning)
            {
                Room previousRoom = null;
                output.WriteLine(game.Player.Location);

                if (previousRoom != game.Player.Location)
                {
                    Game.Look(game);
                    previousRoom = game.Player.Location;
                }

                output.Write("\n> ");
                input.ProcessInput();
            }

            output.WriteLine(string.IsNullOrWhiteSpace(game.ExitMessage) ? "Thank you for playing!" : game.ExitMessage);
        }

        private enum CommandLineArguments
        {
            GameFilename = 0
        }
    }
}