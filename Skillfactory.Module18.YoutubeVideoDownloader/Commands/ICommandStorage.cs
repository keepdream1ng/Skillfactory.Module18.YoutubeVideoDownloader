namespace Skillfactory.Module18.YoutubeVideoDownloader.Commands
{
    public interface ICommandStorage
    {
        List<IVideoCommand> List { get; }

        void Add(IVideoCommand command);
    }
}