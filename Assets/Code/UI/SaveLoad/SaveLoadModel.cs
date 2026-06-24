using Code.Progress;
using Code.Progress.Services;

namespace Code.UI.SaveLoad
{
    public sealed class SaveLoadModel
    {
        private readonly IProgressService _progressService;

        public SaveLoadModel(IProgressService progressService)
        {
            _progressService = progressService;
        }
        
        public bool hasFileSavedProgress => SaveLoadData.HasFileSavedProgress;
        
        public void Save()
        {
            UpdateProgress();
            _progressService.SaveProgress();
        }

        public void Load() =>
            _progressService.LoadProgress();
        
        public void Create() =>
            _progressService.CreateProgress();
        
        public void Delete() =>
            _progressService.DeleteProgress();
        
        
        private void UpdateProgress() =>
            _progressService.UpdateProgress();
    }
}