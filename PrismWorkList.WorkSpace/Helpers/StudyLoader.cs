using PrismWorkList.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList.WorkSpace.Helpers
{
    class StudyLoader
    {
      public IEnumerable<StudyOrder> FetchWorkList()
        {
            var dp = new Dapper();

            var studies = dp.FetchWorkList(null,null);

            foreach (StudyOrder study in studies)
            {
                yield return study;
            }
        }
    }
}
