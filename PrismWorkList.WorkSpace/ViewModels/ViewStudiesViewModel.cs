using Prism.Commands;
using Prism.Mvvm;
using PrismWorkList.Infrastructure.Models;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class ViewStudiesViewModel : BindableBase
    {
        // 検査一覧
        //public ReactiveCollection<StudyViewModel> Studies { get; private set; }
        public ObservableCollection<StudyViewModel> Studies { get; }

        /// <summary>
        ///
        /// </summary>
        public ICollectionView StudiesView { get; }

        public ViewStudiesViewModel()
        {
            this.Studies = new  ObservableCollection<StudyViewModel>();
            {
        
            };
        }
    }
}
