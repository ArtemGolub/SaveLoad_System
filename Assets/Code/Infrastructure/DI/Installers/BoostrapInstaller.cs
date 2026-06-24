using System;
using System.Threading;
using Code.Progress.Services;
using Code.UI.Factories;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.DI.Installers
{
    public sealed class BoostrapInstaller : IInitializable, IDisposable
    {
        private readonly IObjectResolver _objectResolver;
        private readonly IProgressService _progressService;
    
        private CancellationTokenSource _shutdownCts;
        private readonly IUIFactory _uiFactory;

        public BoostrapInstaller(
            IProgressService progressService,
            IUIFactory uiFactory)
        {
            _progressService = progressService;
            _uiFactory = uiFactory;
        }
        
        public static void InstallDependencies(IContainerBuilder builder)
        {
            new ProgressInstaller().Install(builder);
            new ScoreInstaller().Install(builder);
            new UIInstaller().Install(builder);

            builder.RegisterEntryPoint<BoostrapInstaller>();
        }

        public void Initialize()
        {
            _shutdownCts = new CancellationTokenSource();
            
            _progressService.LoadProgress();
            _uiFactory.CreateUI();
        }

        public void Dispose()
        {
            _progressService.SaveProgress();
            
            _shutdownCts?.Cancel();
            _shutdownCts?.Dispose();
            _shutdownCts = null;
        }

        
    }
}