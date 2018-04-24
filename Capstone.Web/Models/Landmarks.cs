using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Landmark
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Latitude { get; set; }
        public int Longtiude { get; set; }
        public string PicName { get; set; }
        public bool ThumbsUp { get; set; }
        public string QueryString
        {
            get
            {
                return Name.Trim().Replace(' ', '+');
            } 
        }
    }
}