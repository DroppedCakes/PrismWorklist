using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class ViewNavigatorViewModel : BindableBase
    {
        // 患者属性情報表示コマンド
        public ReactiveCommand ShowPatientCommand { get; }

        // 検査詳細表示コマンド
        public ReactiveCommand ShowOrderCommand { get; }

        // 設定画面表示コマンド
        public ReactiveCommand ShowConfigCommand { get; }

        // 検査取消コマンド
        public ReactiveCommand OrderCancelCommand { get; }

        public ViewNavigatorViewModel()
        {

        }
    }
}
