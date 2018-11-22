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

        public int? duree { get; set; }


        public int granted { get; set; }

        public int typeLeave { get; set; }



    }
}