using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BritehouseMongo.ViewModel
{
    public class PeopleViewModelChart
    {
        public int Africa_count { get; set; }
        public int Europe_count { get; set; }
        public int USA_count { get; set; }
        public int Asia_count { get; set; }
        public int Caribbean_count { get; set; }
        public int Canada_count { get; set; }
        public int Oceania_count { get; set; }

        //returns
        public double AfricaR { get; set; }
        public double EuropeR { get; set; }
        public double USAR { get; set; }
        public double AsiaR { get; set; }
        public double CaribbeanR { get; set; }
        public double CanadaR { get; set; }
        public double OceaniaR { get; set; }

        public int cp { get; set; }
        public int cr { get; set; }
        public int co { get; set; }



    }
}