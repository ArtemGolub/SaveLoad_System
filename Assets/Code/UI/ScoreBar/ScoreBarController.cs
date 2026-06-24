using Code.Meta.Score.Services;
using R3;
using TMPro;
using UnityEngine;
using VContainer;

namespace Code.UI.ScoreBar
{
    public sealed class ScoreBarController : MonoBehaviour
    {
        private IScoreService _scoreService;

        [SerializeField] private TextMeshProUGUI _scoreText;

        private ScoreBarModel _model;
        private ScoreBarView _view;

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
            _disposables.Clear();
        }

        private void Initialize()
        {
            _model = new ScoreBarModel();

            _view = new ScoreBarView(
                _scoreText
            );
        }

        private void Subscribe()
        {
            _scoreService.CurrentAmount
                .Subscribe(SetScore)
                .AddTo(_disposables);
        }

        private void SetScore(int score)
        {
            _model.SetScore(score);
            _view.SetScore(_model.GetScore());
        }
    }
}