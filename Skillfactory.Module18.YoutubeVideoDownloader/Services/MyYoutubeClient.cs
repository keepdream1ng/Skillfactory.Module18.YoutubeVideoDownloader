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
        public async ValueTask<Video> GetVideoInfo(string videoURL, CancellationToken cancellationToken)
        {
            try
            {
                return await Videos.GetAsync(videoURL, cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async ValueTask DownloadVideo(string videoURL, string outputFile, IProgress<double> progress = null, CancellationToken cancellationToken = default)
        {
            try
            {
                await Videos.DownloadAsync(videoURL, outputFile, progress, cancellationToken);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
