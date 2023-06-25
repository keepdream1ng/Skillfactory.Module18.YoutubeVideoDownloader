using YoutubeExplode.Videos;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public interface ICommandFactory
    {
        void NewDownload(IVideo video);
        void NewVideoInfo(string videoURL);
    }
}