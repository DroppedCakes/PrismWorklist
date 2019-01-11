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
            containerRegistry.RegisterSingleton<WorkSpaceViewModel>();
            containerRegistry.RegisterForNavigation<WorkSpaceView>();
            containerRegistry.RegisterSingleton<ViewStudiesViewModel>();
            containerRegistry.RegisterForNavigation<ViewStudies>();
            containerRegistry.RegisterForNavigation<CriteriaView>();
            containerRegistry.RegisterForNavigation<NavigatorView>();
        }
    }
}