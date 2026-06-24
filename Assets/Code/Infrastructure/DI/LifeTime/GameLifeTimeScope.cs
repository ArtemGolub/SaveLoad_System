using Code.Infrastructure.DI.Installers;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.DI.LifeTime
{
    public sealed class GameLifeTimeScope: LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder) =>
            BoostrapInstaller.InstallDependencies(builder);
        
    }
}