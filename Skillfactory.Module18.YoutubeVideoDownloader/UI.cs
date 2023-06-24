using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public class UI : IUI
    {
        private readonly ILogger<UI> _log;
        private readonly IConfiguration _config;

        public UI(ILogger<UI> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void Run()
        {
            ConsoleKey input;
            while (true)
            {
                Console.WriteLine("Press Q to exit");
                input = Console.ReadKey(true).Key;
                _log.LogInformation("User pressed {input}", input);
                switch (input)
                {
                    case ConsoleKey.Q:
                        {
                            _log.LogInformation("Exiting programm");
                            return;
                        }
                    default: break;
                }
            }
        }
    }
}
