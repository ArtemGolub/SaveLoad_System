using Code.UI.Factories;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.DI.Installers
{
    public sealed class UIInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            InstallFactories(builder);
        }
        
        private void InstallFactories(IContainerBuilder builder)
        {
            builder.Register<UIFactory>(Lifetime.Singleton)
                .As<IUIFactory>()
                .AsSelf();
        }
    }
}