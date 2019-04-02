using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismWorkList.Infrastructure.Models
{
    public class Settings : BindableBase
    {
        public Settings()
        {

        }

        private bool _isAutoReloaded;
        public bool IsAutoReloaded
        {
            get { return _isAutoReloaded; }
            set { SetProperty(ref _isAutoReloaded, value); }
        }

        private int  _autoReloadSpan;
        public int AutoReloadSpan
        {
            get { return _autoReloadSpan; }
            set { SetProperty(ref _autoReloadSpan, value); }
        }


    }
}
