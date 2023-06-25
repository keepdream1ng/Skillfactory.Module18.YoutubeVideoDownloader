using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace Skillfactory.Module18.YoutubeVideoDownloader.Commands
{
    public interface IVideoCommand : ICommand
    {
        public IVideo VideoInfo { get; }
    }
}
