using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_Model_A00972836
{
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(RegionMetaData))]

    public partial class Region
    {
    }

    public class RegionMetaData
    {

        public int RegionID { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be between {2} and {1} chars.", MinimumLength = 4)]
        [Display(Name = "REGION DESCRIPTION")]
        public object RegionDescription { get; set; }
    }
}