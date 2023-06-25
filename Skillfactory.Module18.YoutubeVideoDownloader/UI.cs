using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AngleSharp.Text;
using Skillfactory.Module18.YoutubeVideoDownloader.Commands;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public class UI : IUI
    {
        private readonly ILogger<UI> _log;
        private readonly IManagerForVIdCommands _manager;

        public UI(ILogger<UI> log, IConfiguration config, IManagerForVIdCommands manager)
        {
            _log = log;
            _manager = manager;
        }

        public void Run()
        {
            GetSelectionInput();
        }

        private void GetSelectionInput()
        {
            ConsoleKeyInfo input;
            while (true)
            {
                Console.WriteLine("Press 'N' to input new URL, press 0 - 9 for selecting previous commands, 'A' to select them all, 'Q' to quit.");
                input = Console.ReadKey(true);
                _log.LogInformation("User pressed {input}", input.Key);
                if (input.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Enter the video URL");
                    _manager.GetInfoFrom(Console.ReadLine());
                }
                if (input.Key == ConsoleKey.A)
                {
                    _log.LogInformation("User selected all active commands");
                    _manager.ApplyForAll(GetActionInput());
                }
                if (input.KeyChar.IsDigit())
                {
                    int index = int.Parse(input.KeyChar.ToString());
                    _log.LogInformation("Selected index {index}", index);
                    _manager.ApplyForSelectedIndex(index, GetActionInput());
                }
                if (input.Key == ConsoleKey.Q)
                {
                    _log.LogInformation("User exiting the app.");
                    return;
                }
            }
        }

        private Action<IVideoCommand> GetActionInput()
        {
            Console.WriteLine("Press 'D' to download selected, 'C' to cancel selected command");
            ConsoleKeyInfo input;
            while (true)
            {
                input = Console.ReadKey(true);
                _log.LogInformation("User pressed {input}", input.Key);

                if (input.Key == ConsoleKey.D)
                {
                    return ((IVideoCommand c) => _manager.DownloadBasedOnInfo(c));
                }

                if (input.Key == ConsoleKey.C)
                {
                    return ((IVideoCommand c) => _manager.CancelCommand(c));
                }
            }
        }
    }
}
