using Code.Meta.Score.Services;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Code.UI.ScoreManipulator
{
    // TODO Required for splitting updatable and static canvases
    public sealed class ScoreManipulatorController : MonoBehaviour
    {
        [SerializeField] private Button _btnIncrease;
        [SerializeField] private Button _btnDecrease;

        // TODO should be in game settings
        private const int MAX_AMOUNT = 10;
        private const int MIN_AMOUNT = 0;

        private IScoreService _scoreService;

        private ScoreManipulatorModel _model;
        private ScoreManipulatorView _view;

        private readonly CompositeDisposable _disposables = new();

        [Inject]
        public void Construct(IScoreService scoreService)
        {
            _scoreService = scoreService;
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
            _model = new ScoreManipulatorModel(
                _scoreService,
                (MIN_AMOUNT, MAX_AMOUNT)
            );

            _view = new ScoreManipulatorView(
                _btnIncrease,
                _btnDecrease
            );

            UpdateButtonState();
        }

        private void Subscribe()
        {
            _btnIncrease.onClick.AddListener(OnIncreaseButtonClicked);
            _btnDecrease.onClick.AddListener(OnDecreaseButtonClicked);

            _scoreService.CurrentAmount
                .Subscribe(OnScoreChanged)
                .AddTo(_disposables);
        }

        private void Unsubscribe()
        {
            _btnIncrease.onClick.RemoveListener(OnIncreaseButtonClicked);
            _btnDecrease.onClick.RemoveListener(OnDecreaseButtonClicked);

            _disposables.Clear();
        }

        private void OnIncreaseButtonClicked()
        {
            IncreaseScore();
        }

        private void OnDecreaseButtonClicked()
        {
            DecreaseScore();
        }

        private void IncreaseScore(int amount = 1)
        {
            if (_model.CanIncrease(amount))
                _model.IncreaseScore(amount);

            UpdateButtonState();
        }

        private void DecreaseScore(int amount = 1)
        {
            if (_model.CanDecrease(amount))
                _model.DecreaseScore(amount);

            UpdateButtonState();
        }

        private void OnScoreChanged(int score)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            _view.SetIncreaseButtonInteractable(!_model.isMax());
            _view.SetDecreaseButtonInteractable(!_model.isMin());
        }
    }
}