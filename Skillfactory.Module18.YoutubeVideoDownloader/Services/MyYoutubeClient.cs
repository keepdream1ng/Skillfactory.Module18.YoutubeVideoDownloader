using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;

namespace Skillfactory.Module18.YoutubeVideoDownloader.Services
{
    // In the name of SOLID, this shall be done...
    public class MyYoutubeClient : YoutubeClient, IVideoInfoService, IVideoDownloader
    {
        public async ValueTask<Video> GetVideoInfo(string videoURL)
        {
            return await Videos.GetAsync(videoURL);
        }

        public async ValueTask DownloadVideo(string videoURL, string outputFile, IProgress<double> progress = null, CancellationToken cancellationToken = default)
        {
            await Videos.DownloadAsync(videoURL, outputFile, progress, cancellationToken);
        }
    }
}
