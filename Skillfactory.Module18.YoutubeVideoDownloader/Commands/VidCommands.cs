using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillfactory.Module18.YoutubeVideoDownloader.Commands
{
    public class VidCommands : ICommandStorage, ICommandCanceller
    {
        public List<IVideoCommand> List { get; private set; }

        public VidCommands()
        {
            List = new List<IVideoCommand>();
        }

        public void Add(IVideoCommand command)
        {
            command.Execute();
            List.Add(command);
        }

        public bool Remove(IVideoCommand command)
        {
            command.Cancel();
            return List.Remove(command);
        }
    }
}
