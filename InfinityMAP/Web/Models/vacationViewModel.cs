using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class vacationViewModel
    {
        public int id { get; set; }

        public DateTime? dateStart { get; set; }

        public DateTime? dateEnd { get; set; }

        public int? resource_id { get; set; }


    }
}