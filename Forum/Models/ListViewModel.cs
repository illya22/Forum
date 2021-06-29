using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Forum.Models
{
    public class ListViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}