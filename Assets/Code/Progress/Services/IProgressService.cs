namespace Code.Progress.Services
{
    public interface IProgressService
    {
        void SaveProgress();
        void LoadProgress();
        void DeleteProgress();
        void CreateProgress();
        void UpdateProgress();
    }
}