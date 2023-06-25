using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skillfactory.Module18.YoutubeVideoDownloader.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace Skillfactory.Module18.YoutubeVideoDownloader.Commands
{
    public class DownloadVideoCommand : IVideoCommand
    {
        public IVideo VideoInfo { get; private set; }
        private IVideoDownloader _videoProvider;
        private CancellationTokenSource _cancellationTokenSource;
        private IConfiguration _config;
        private readonly ILogger<IVideoCommand> _logger;

        private string _filename
        {
            get
            {
                return $"{VideoInfo.Title}.{_config.GetValue<string>("OutputFormat")}";
            }
        }

        public DownloadVideoCommand(IVideo vidInfo,
            IVideoDownloader vidProvider,
            IConfiguration config,
            ILogger<IVideoCommand> logger)
        {
            VideoInfo = vidInfo;
            _videoProvider = vidProvider;
            _cancellationTokenSource = new CancellationTokenSource();
            _config = config;
            _logger = logger;
        }

        public async void Execute()
        {
            _logger.LogInformation("{action} video from {URL}", "Downloading", VideoInfo.Url);
            await _videoProvider.DownloadVideo(VideoInfo.Url, _filename, null, _cancellationTokenSource.Token);
            _logger.LogInformation("{action} video from {URL}", "Finished download", VideoInfo.Url);
        }

        public void Cancel()
        {
            _logger.LogInformation("{action} video from {URL}", "Aborting download", VideoInfo.Url);
            _cancellationTokenSource?.Cancel();
        }
    }
}
