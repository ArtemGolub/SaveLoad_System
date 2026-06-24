namespace Code.Progress.Services.ValidateService
{
    public interface IValidateService
    {
        bool TryValidate<T>(T data);
    }
}