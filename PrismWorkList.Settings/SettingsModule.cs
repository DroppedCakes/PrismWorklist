using PrismWorkList.SettingsMenu.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWorkList.SettingsMenu.ViewModels;

namespace PrismWorkList.SettingsMenu
{
    public class SettingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<SettingsViewModel>();
            containerRegistry.RegisterForNavigation<Views.SettingsMenu>();
        }
    }
}