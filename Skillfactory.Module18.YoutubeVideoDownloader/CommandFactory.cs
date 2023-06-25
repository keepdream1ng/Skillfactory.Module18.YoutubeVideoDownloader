using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skillfactory.Module18.YoutubeVideoDownloader.Commands;
using Skillfactory.Module18.YoutubeVideoDownloader.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode.Videos;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public class CommandFactory : ICommandFactory
    {
        public ICommandStorage CommandStorage { get;}
        private readonly IVideoDownloader _videoDownloader;
        private readonly IVideoInfoService _videoInfoService;
        private readonly IConfiguration _config;
        private readonly ILogger<IVideoCommand> _commandLogger;
        private readonly ILogger<CommandFactory> _factoryLogger;

        public CommandFactory(ICommandStorage commandStorage,
            IVideoDownloader videoDownloader,
            IVideoInfoService videoInfoService,
            IConfiguration config,
            ILogger<IVideoCommand> commandLogger,
            ILogger<CommandFactory> factoryLogger
            )
        {
            CommandStorage = commandStorage;
            _videoDownloader = videoDownloader;
            _videoInfoService = videoInfoService;
            _config = config;
            _commandLogger = commandLogger;
            _factoryLogger = factoryLogger;
        }

        public void NewVideoInfo(string videoURL)
        {
            _factoryLogger.LogInformation("Creating command for {URL} video {action}", videoURL, "info");
            CommandStorage.Add(new GetVideoInfoCommand(videoURL, _videoInfoService, _commandLogger));
        }

        public void NewDownload(IVideo video)
        {
            _factoryLogger.LogInformation("Creating command for {URL} video {action}", video.Url, "download");
            CommandStorage.Add(new DownloadVideoCommand(video, _videoDownloader, _config, _commandLogger));
        }
    }
}
