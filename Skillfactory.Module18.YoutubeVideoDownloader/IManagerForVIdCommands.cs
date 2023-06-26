using Skillfactory.Module18.YoutubeVideoDownloader.Commands;

namespace Skillfactory.Module18.YoutubeVideoDownloader
{
    public interface IManagerForVIdCommands
    {
        void GetInfoFrom(string URL);
        void ApplyForAll(Action<IVideoCommand> action);
        void ApplyForSelectedIndex(int index, Action<IVideoCommand> action);
        void CancelCommand(IVideoCommand command);
        void DownloadBasedOnInfo(IVideoCommand command);
        void GetCommandInfo(IVideoCommand command);
    }
}