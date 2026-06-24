namespace Code.Progress.Services.LoadService
{
    public interface ILoadService
    {
        bool TryLoad<T>(string filePath, out T data);
    }
}