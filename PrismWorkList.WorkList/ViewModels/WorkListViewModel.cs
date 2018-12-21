using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using PrismWorkList.Infrastructure.Models;

namespace PrismWorkList.WorkList.ViewModels
{
    public class WorkListViewModel : BindableBase
    {
        public IEnumerable<OrderPatientView> WorkList { get; set; }

        public WorkListViewModel()
        {
            var db = new Dapper();

            WorkList = db.FetchWorkList();
        }
    }
}
