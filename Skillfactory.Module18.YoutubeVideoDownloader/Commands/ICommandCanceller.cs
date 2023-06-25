namespace Skillfactory.Module18.YoutubeVideoDownloader.Commands
{
    public interface ICommandCanceller
    {
        List<IVideoCommand> List { get; }

        bool Remove(IVideoCommand command);
    }
}