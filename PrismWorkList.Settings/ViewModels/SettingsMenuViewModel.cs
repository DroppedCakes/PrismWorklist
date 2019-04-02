using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Reactive.Linq;

namespace PrismWorkList.SettingsMenu.ViewModels
{
    public class SettingsViewModel : BindableBase, INavigationAware
    {
        private IRegionNavigationService _regionNavigationService { get; set; }

        public ReactiveCommand BackWorkSpaceCommand { get; }// = new ReactiveCommand();

        public ReactiveCommand SaveCommand { get; } = new ReactiveCommand();

        public ReactiveProperty<bool> IsAutoReloaded { get; } = new ReactiveProperty<bool>();

        public SettingsViewModel()
        {
            BackWorkSpaceCommand = new ReactiveCommand().WithSubscribe(BackPage);
        }

        private void SaveSettings()
        {

        }
        //=> _regionNavigationService.RequestNavigate(nameof("ViewWorkSpace"));

        private void BackPage()
            => _regionNavigationService.Journal.GoBack();

        #region INavigationAware

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _regionNavigationService = navigationContext.NavigationService;
//            BackWorkSpaceCommand.Subscribe(() => BackPage());
            IsAutoReloaded.Value = true;

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
        #endregion INavigationAware
    }
}
