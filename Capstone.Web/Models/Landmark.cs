﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Landmark
    {
        public string Address { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
        public int Latitude { get; set; }
        public int Longtiude { get; set; }

    }
}