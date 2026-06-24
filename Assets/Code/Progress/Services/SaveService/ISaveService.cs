namespace Code.Progress.Services.SaveService
{
    public interface ISaveService
    {
        public bool TrySave<T>(string filePath, T data);
    }
}