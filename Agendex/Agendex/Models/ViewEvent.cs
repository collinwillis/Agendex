using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agendex.Models
{
    public class ViewEvent
    {
        public Int64 id { get; set; }

        public String title { get; set; }

        public String start { get; set; }

        public String end { get; set; }

        public String description { get; set; }
    }
}