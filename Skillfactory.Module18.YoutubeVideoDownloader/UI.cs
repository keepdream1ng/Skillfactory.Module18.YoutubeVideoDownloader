using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AngleSharp.Text;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public class UI : IUI
    {
        private readonly ILogger<UI> _log;
        private readonly IConfiguration _config;
        private readonly IManagerForVIdCommands _manager;

        public UI(ILogger<UI> log, IConfiguration config, IManagerForVIdCommands manager)
        {
            _log = log;
            _config = config;
            _manager = manager;
        }

        public void Run()
        {
            GetSelectionInput();
        }

        private void GetSelectionInput()
        {
            Console.WriteLine("Press 'N' to input new URL, press 0 - 9 for selecting previous commands, 'A' to select them all, 'Q' to quit.");
            ConsoleKeyInfo input;
            while (true)
            {
                input = Console.ReadKey(true);
                _log.LogInformation("User pressed {input}", input.Key);
                if (input.Key == ConsoleKey.N)
                {
                    _manager.GetInfoFrom(Console.ReadLine());
                }
                if (input.Key == ConsoleKey.A)
                {
                    _log.LogInformation("User selected all active commands");
                }
                if (input.KeyChar.IsDigit())
                {
                    int index = int.Parse(input.KeyChar.ToString());
                    _log.LogInformation("Selected index {index}", index);
                }
                if (input.Key == ConsoleKey.Q)
                {
                    _log.LogInformation("User exiting the app.");
                    return;
                }
            }
        }
    }
}
