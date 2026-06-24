namespace Code.Progress.Services.DeleteService
{
    public interface IDeleteService
    {
        bool TryDelete(string filePath);
    }
}