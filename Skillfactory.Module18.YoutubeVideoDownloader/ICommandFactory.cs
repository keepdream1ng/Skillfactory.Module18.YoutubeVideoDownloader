using Skillfactory.Module18.YoutubeVideoDownloader.Commands;
using YoutubeExplode.Videos;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public interface ICommandFactory
    {
        ICommandStorage CommandStorage { get; }
        void NewDownload(IVideo video);
        void NewVideoInfo(string videoURL);
    }
}