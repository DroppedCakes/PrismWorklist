using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismWorkList.WorkSpace.ViewModels
{
    public class CriteriaViewModel : BindableBase
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime StudyDateSince { get; set; } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public DateTime StudyDateUntil { get; set; }=DateTime.Now;

        public CriteriaViewModel()
        {

        }
    }
}
