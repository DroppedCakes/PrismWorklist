using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismWorkList
{
    public class ViewNavigator
    {

        public ViewNavigator()
        {

        }

        public void RequestNavigate(IRegionManager regionManager)
        {
            var regionName = "ContentRegion";
            //regionManager.RequestNavigate(regionName, viewName);
        }

        public void GoBack()
        {

        }

        public void GoFront()
        {

        }

    }
}
