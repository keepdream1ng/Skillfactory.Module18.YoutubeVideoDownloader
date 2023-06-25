namespace Skillfactory.Module18.YoutubeVideoDownloader.Commands
{
    public interface ICommandCanceller
    {
        bool Remove(IVideoCommand command);
    }
}