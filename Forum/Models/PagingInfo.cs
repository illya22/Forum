using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class PagingInfo
    {
        public int Total_Topics { get; set; }
        public int Topics_Per_Page { get; set; }
        public int Current_Page { get; set; }
        public int Total_Pages
        {
            get
            {
                return (int)Math.Ceiling
                  ((decimal)Total_Topics / Topics_Per_Page);
            }
        }
    }
}