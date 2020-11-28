using System;
using System.Collections.Generic;
using System.Text;

namespace RoutePlanner.net
{
    public class Connection
    {
        public string From { get; set; }
        public string ToRoute {get; set;}
        public bool Bidirectional {get; set;}
        public int Cost {get; set;}
        public string Custom {get; set;}
    }
}
