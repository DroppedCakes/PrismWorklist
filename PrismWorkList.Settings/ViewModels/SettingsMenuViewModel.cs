using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace PrismWorkList.SettingsMenu.ViewModels
{
    public class SettingsViewModel : BindableBase
    {

        public ReactiveCommand NavigationWorkSpace { get; }

        public SettingsViewModel()
        {

        }

        /// <summary>
        /// WorkSpaceに遷移
        /// </summary>
        private void NavigateWorkSpace()
        {
        }
    }
}
