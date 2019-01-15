using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class ViewCriteriaViewModel : BindableBase
    {
        /// <summary>
        /// から
        /// </summary>
        public ReactiveProperty<DateTime> StudyDateSince { get; set; } = new ReactiveProperty<DateTime>(DateTime.Now);

        /// <summary>
        /// まで
        /// </summary>
        public ReactiveProperty<DateTime> StudyDateUntil { get; set; } = new ReactiveProperty<DateTime>(DateTime.Now);

        // 検索条件クリアコマンド
        public ReactiveCommand SearchCriteriaClearCommand{ get; }

        // ワークリスト更新コマンド
        public ReactiveCommand StudiesReloadCommand { get; }

        // デフォルトコンストラクタ
        //public ViewCriteriaViewModel()
        //{

        //}

        // 本番用コンストラクタ
        public ViewCriteriaViewModel()
        {
            
        }
    }
}
