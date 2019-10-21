using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace R_bookWY.Models
{
    public class dhl
    {
        public string id { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string spread { get; set; }
        public string href { get; set; }
        public dhl children { get; set; }

    }
}