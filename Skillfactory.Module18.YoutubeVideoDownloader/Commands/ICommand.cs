using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillfactory.Module18.YoutubeVideoDownloader.Commands
{
    public interface ICommand
    {
        public void Execute();
        public void Cancel();
    }
}
