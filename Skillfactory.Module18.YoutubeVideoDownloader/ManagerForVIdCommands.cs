using Microsoft.Extensions.Logging;
using Skillfactory.Module18.YoutubeVideoDownloader.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public class ManagerForVIdCommands : IManagerForVIdCommands
    {
        private readonly ICommandFactory _factory;
        private readonly ICommandCanceller _canceller;
        private readonly ILogger<ManagerForVIdCommands> _logger;

        public ManagerForVIdCommands(ICommandFactory factory,
            ICommandCanceller canceller,
            ILogger<ManagerForVIdCommands> logger
            )
        {
            _factory = factory;
            _canceller = canceller;
            _logger = logger;
        }

        public void ApplyForSelectedIndex(int index, Action<IVideoCommand> action)
        {
            if (_factory.CommandStorage.List.Count > index)
            {
                action(_factory.CommandStorage.List[index]);
            }
            else
            {
                _logger.LogError("Command index {index} is missing", index);
            }
        }

        public void ApplyForAll(Action<IVideoCommand> action)
        {
            // Iterating list from the end give the option to safely remove elements.
            for (int i = _factory.CommandStorage.List.Count - 1; i >= 0; i--)
            {
                action(_factory.CommandStorage.List[i]);
            }
        }

        public void CancelCommand(IVideoCommand command)
        {
            _canceller.Remove(command);
        }

        public void GetInfoFrom(string URL)
        {
            _factory.NewVideoInfo(URL);
        }

        public void DownloadBasedOnInfo(IVideoCommand command)
        {
            if ((command is not GetVideoInfoCommand) || (command.VideoInfo is null))
            {
                return;
            }
            _factory.NewDownload(command.VideoInfo);
            // Removing command for just getting info, now list has this info but in the Download command.
            _canceller.Remove(command);
        }

        public void GetCommandInfo(IVideoCommand command)
        {
            if (command.VideoInfo != null)
            {
                Console.WriteLine($"#{_factory.CommandStorage.List.IndexOf(command)} {command.VideoInfo.Title} {command.VideoInfo.Duration}");
            }
        }
    }
}
