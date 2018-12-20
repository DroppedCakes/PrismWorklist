using PrismWorkList.Login.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWorkList.Login.ViewModels;

namespace PrismWorkList.Login
{
    public class LoginModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionMan = containerProvider.Resolve<IRegionManager>();
            regionMan.RegisterViewWithRegion("EditorArea", typeof(Views.LoginView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<LoginViewModel>();
            containerRegistry.RegisterForNavigation<LoginView>();
        }
    }
}