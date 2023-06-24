using YoutubeExplode;
using YoutubeExplode.Converter;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var youtube = new YoutubeClient();

            var videoUrl = "https://www.youtube.com/watch?v=Zd3Mh3TeOGI";
            Console.WriteLine("getting data");

            var vid = youtube.Videos.GetAsync(videoUrl);
            Console.WriteLine(vid.Result.Title);

            CancellationTokenSource CancelToken = new();
            DownloadVid(videoUrl, CancelToken.Token);

            Console.WriteLine("Press ESC to cancel donload");
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.Escape:
                    {
                        CancelToken.Cancel(false);
                        Console.WriteLine("CancellingDonload...");
                        break;
                    }
                default: break;
            }
            
            Console.ReadKey();
        }

        static async Task DownloadVid(string videoUrl, CancellationToken ChancelToken)
        {
            var youtube = new YoutubeClient();
            await youtube.Videos.DownloadAsync(videoUrl, "video.mp4", null, ChancelToken);
            Console.WriteLine("done");
        }
    }
}