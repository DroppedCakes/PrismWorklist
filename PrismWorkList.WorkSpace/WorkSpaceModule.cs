using Prism.Ioc;
using Prism.Modularity;
using PrismWorkList.WorkSpace.ViewModels;
using PrismWorkList.WorkSpace.Views;

namespace PrismWorkList.WorkSpace
{
    public class WorkSpaceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ViewWorkSpaceViewModel>();
            containerRegistry.RegisterForNavigation<ViewWorkSpace>();
            containerRegistry.RegisterForNavigation<ViewStudies>();
            containerRegistry.RegisterForNavigation<ViewCriteria>();
            containerRegistry.RegisterForNavigation<ViewNavigator>();
        }
    }
}