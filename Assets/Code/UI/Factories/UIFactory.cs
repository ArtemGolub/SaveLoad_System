using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.UI.Factories
{
    // Simplified
    public sealed class UIFactory : IUIFactory
    {
        private readonly IObjectResolver _objectResolver;

        public UIFactory(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        public void CreateUI()
        {
            UIConfig config = Resources.Load<UIConfig>("UIConfig");
            
            _objectResolver.Instantiate(config.ScoreBarPrefab);
            _objectResolver.Instantiate(config.ScoreManipulatorPrefab);
            _objectResolver.Instantiate(config.SaveLoadPrefab);
        }
    }
}