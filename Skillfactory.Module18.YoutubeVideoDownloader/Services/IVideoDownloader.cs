namespace Skillfactory.Module18.YoutubeVideoDownloader.Services
{
    public interface IVideoDownloader
    {
        /// <summary>
        /// Downloads a video with a specified URL for selected path and a file format after dot.
        /// </summary>
        ValueTask DownloadVideo(string videoURL, string outputFile, IProgress<double> progress = null, CancellationToken cancellationToken = default);
    }
}