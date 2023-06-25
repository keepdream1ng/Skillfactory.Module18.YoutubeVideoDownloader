using YoutubeExplode.Videos;

namespace Skillfactory.Module18.YoutubeVideoDownloader.Services
{
    public interface IVideoInfoService
    {
        /// <summary>
        /// Returns a Video info class, from the specified URL.
        /// </summary>
        ValueTask<Video> GetVideoInfo(string videoURL, CancellationToken cancellationToken);
    }
}