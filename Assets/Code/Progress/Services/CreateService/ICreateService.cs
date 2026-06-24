namespace Code.Progress.Services.CreateService
{
    public interface ICreateService
    {
        bool TryCreate<T>(out T data) where T : new();
    }
}