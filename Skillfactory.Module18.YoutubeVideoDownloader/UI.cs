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
            Console.WriteLine("Tip: Press 'A' and 'I' to get list of videos you working with with command indexes");
            ConsoleKeyInfo input;
            while (true)
            {
                Console.WriteLine("Press 'N' to input new URL, press 0 - 9 for selecting previous commands, 'A' to select them all, 'Q' to quit.");
                input = Console.ReadKey(true);
                if (input.KeyChar.IsDigit())
                {
                    int index = int.Parse(input.KeyChar.ToString());
                    _log.LogInformation("Selected index {index}", index);
                    _manager.ApplyForSelectedIndex(index, GetActionInput());
                } 
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
                if (input.Key == ConsoleKey.Q)
                {
                    _log.LogInformation("User exiting the app.");
                    return;
                }
            }
        }

        private Action<IVideoCommand> GetActionInput()
        {
            Console.WriteLine("Press 'I' for video info, 'D' to download selected, 'C' to remove and cancel selected command");
            ConsoleKeyInfo input;
            while (true)
            {
                input = Console.ReadKey(true);
                switch (input.Key)
                {
                    case ConsoleKey.D:
                        return ((IVideoCommand c) => _manager.DownloadBasedOnInfo(c));
                    case ConsoleKey.C:
                        return ((IVideoCommand c) => _manager.CancelCommand(c));
                    case ConsoleKey.I:
                        return ((IVideoCommand c) => _manager.GetCommandInfo(c));
                    default: break;
                }
            }
        }
    }
}
