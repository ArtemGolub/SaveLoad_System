using Code.Progress.Services;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.UI.SaveLoad
{
    public sealed class SaveLoadController: MonoBehaviour
    {
        private IProgressService _progressService;
        
        [SerializeField] private Button _btnSave;
        [SerializeField] private Button _btnLoad;
        [SerializeField] private Button _btnDelete;
        [SerializeField] private Button _btnCreate;
        
        private SaveLoadModel _model;
        private SaveLoadView _view;

        [Inject]
        public void Construct(
            IProgressService progressService)
        {
            _progressService = progressService;

        }

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }


        private void Initialize()
        {
            _model = new SaveLoadModel(
                _progressService
            );
            
            _view = new SaveLoadView(
                (_btnSave, _btnLoad, _btnDelete, _btnCreate)
            );
            
            
        }
        
        private void Subscribe()
        {
            _btnSave.onClick.AddListener(Save);
            _btnLoad.onClick.AddListener(Load);
            _btnDelete.onClick.AddListener(Delete);
            _btnCreate.onClick.AddListener(Create);
        }

        private void Unsubscribe()
        {
            _btnSave.onClick.RemoveListener(Save);
            _btnLoad.onClick.RemoveListener(Load);
            _btnDelete.onClick.RemoveListener(Delete);
            _btnCreate.onClick.RemoveListener(Create);
        }
        
        private void Save()
        {
            _model.Save();
            _view.UpdateButtonsState(_model.hasFileSavedProgress);
        }

        private void Load()
        { 
            _model.Load();
        }

        private void Create()
        {
            _model.Create();
            _view.UpdateButtonsState(_model.hasFileSavedProgress);
        }

        private void Delete()
        {
            _model.Delete();
            _view.UpdateButtonsState(_model.hasFileSavedProgress);
        }
    }
}