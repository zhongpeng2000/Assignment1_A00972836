using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment1_Model_A00972836;

namespace Assignment1_A00972836.Models
{
    public class RegionView
    {
        public bool isChecked { get; set; }
        public Region region { get; set; }

        public RegionView()
        {

        }


        public RegionView(Region region)
        {
            this.region = region;
            isChecked = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regionList"></param>
        /// <returns></returns>
        public static IList<RegionView> init(IEnumerable<Region> regionList)
        {
            IList<RegionView> RegionViewList = new List<RegionView>();
            foreach (Region region in regionList)
            {
                RegionViewList.Add(new RegionView(region));
            }
            return RegionViewList;
        }
    }
}