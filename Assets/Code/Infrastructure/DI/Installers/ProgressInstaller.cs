using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.Services;
using Code.Progress.Services.CreateService;
using Code.Progress.Services.DeleteService;
using Code.Progress.Services.LoadService;
using Code.Progress.Services.SaveService;
using Code.Progress.Services.UpdateService;
using Code.Progress.Services.ValidateService;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.DI.Installers
{
    public sealed class ProgressInstaller: IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            InstallProvider(builder);
            InstallServices(builder);
        }

        private void InstallServices(IContainerBuilder builder)
        {
            builder.Register<CreateService>(Lifetime.Singleton)
                .As<ICreateService>()
                .AsSelf();
            
            builder.Register<SaveService>(Lifetime.Singleton)
                .As<ISaveService>()
                .AsSelf();
            
            builder.Register<LoadService>(Lifetime.Singleton)
                .As<ILoadService>()
                .AsSelf();
            
            builder.Register<DeleteService>(Lifetime.Singleton)
                .As<IDeleteService>()
                .AsSelf();
            
            builder.Register<UpdateService>(Lifetime.Singleton)
                .As<IUpdateService>()
                .AsSelf();
            
            builder.Register<ValidateService>(Lifetime.Singleton)
                .As<IValidateService>()
                .AsSelf();
            
            builder.Register<ProgressService>(Lifetime.Singleton)
                .As<IProgressService>()
                .AsSelf();
        }

        private void InstallProvider(IContainerBuilder builder)
        {
            builder.Register<ProgressProvider>(Lifetime.Singleton).As<IProgressProvider<ProgressData>>();
        }
    }
}