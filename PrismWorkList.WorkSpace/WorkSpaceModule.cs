using PrismWorkList.WorkSpace.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismWorkList.WorkSpace.ViewModels;

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