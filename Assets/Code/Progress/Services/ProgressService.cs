using Code.Meta.Score;
using Code.Meta.Score.Services;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.Services.CreateService;
using Code.Progress.Services.DeleteService;
using Code.Progress.Services.LoadService;
using Code.Progress.Services.SaveService;
using Code.Progress.Services.UpdateService;
using Code.Progress.Services.ValidateService;
using UnityEngine;

namespace Code.Progress.Services
{
    public sealed class ProgressService : IProgressService
    {
        private readonly IProgressProvider<ProgressData> _progressProvider;
        private readonly IScoreService _scoreService;
        private readonly ILoadService _loadService;
        private readonly ISaveService _saveService;
        private readonly ICreateService _createService;
        private readonly IUpdateService _updateService;
        private readonly IDeleteService _deleteService;
        private readonly IValidateService _validateService;

        public ProgressService(
            IProgressProvider<ProgressData> progressProvider,
            IScoreService scoreService,
            ILoadService loadService,
            ISaveService saveService,
            ICreateService createService,
            IUpdateService updateService,
            IDeleteService deleteService,
            IValidateService validateService)
        {
            _progressProvider = progressProvider;
            _scoreService = scoreService;
            _loadService = loadService;
            _saveService = saveService;
            _createService = createService;
            _updateService = updateService;
            _deleteService = deleteService;
            _validateService = validateService;
        }
        
        public void SaveProgress()
        {
            UpdateProgress();
            
            ProgressData progressData = _progressProvider.progressData;

            if (!_validateService.TryValidate(progressData))
            {
                Debug.LogWarning("ProgressService: Cannot save progress. ProgressData is invalid.");
                return;
            }

            _saveService.TrySave(SaveLoadData.SaveFilePath, progressData);
        }
        
        public void LoadProgress()
        {
            if (!_loadService.TryLoad(SaveLoadData.SaveFilePath, out ProgressData progressData))
            {
                CreateProgress();
                return;
            }

            if (!_validateService.TryValidate(progressData))
            {
                CreateProgress();
                return;
            }

            _progressProvider.SetProgressData(progressData);
        }
        
        public void DeleteProgress() =>
            _deleteService.TryDelete(SaveLoadData.SaveFilePath);
        

        public void CreateProgress()
        {
            if (!_createService.TryCreate(out ProgressData progressData))
                return;

            if (!_validateService.TryValidate(progressData))
                return;

            _progressProvider.SetProgressData(progressData);
            SaveProgress();
        }
        
        public void UpdateProgress()
        {
            ProgressData progressData = _progressProvider.progressData;

            _updateService.TryUpdate(progressData, data =>
            {
                if (!_validateService.TryValidate(data))
                {
                    Debug.LogWarning("ProgressService: Cannot update progress. ProgressData is invalid.");
                    return;
                }

                Score score = _scoreService.GetScore();

                if (score == null)
                {
                    Debug.LogWarning("ProgressService: Cannot update progress. Score is null.");
                    return;
                }

                data.PlayerData.Score = score;
            });
        }
    }
}