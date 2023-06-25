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
    public class GetVideoInfoCommand : IVideoCommand
    {
        public IVideo VideoInfo { get; private set; }
        private string _videoURL;
        private IVideoInfoService _infoProvider;
        private readonly ILogger<IVideoCommand> _logger;
        private CancellationTokenSource _cancellationTokenSource;

        public GetVideoInfoCommand(string videoURL, IVideoInfoService infoService, ILogger<IVideoCommand> logger)
        {
            _videoURL = videoURL;
            _infoProvider = infoService;
            _logger = logger;
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public async void Execute()
        {
            _logger.LogInformation("{action} from {URL}", "Getting info", _videoURL);
            VideoInfo = await _infoProvider.GetVideoInfo(_videoURL, _cancellationTokenSource.Token);
            _logger.LogInformation("{action} from {URL}", "Info obtained", _videoURL);
        }

        public void Cancel()
        {
            _logger.LogInformation("{action} from {URL}", "Aborting getting info", _videoURL);
            _cancellationTokenSource?.Cancel();
        }
    }
}
