using Code.Meta.Score.Services;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.DI.Installers
{
    public sealed class ScoreInstaller: IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            InstallServices(builder);
        }

        private void InstallServices(IContainerBuilder builder)
        {
            builder.Register<ScoreService>(Lifetime.Singleton)
                .As<IScoreService>()
                .AsSelf();
        }
    }
}