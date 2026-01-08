using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace Logic.Resources
{
    

    public class DonationMap : ClassMap<DonationModel>
    {
        public DonationMap()
        {
            Map(p => p.Emailadres).Name("E-mailadres");
            Map(p => p.Name).Name("Naam");
            Map(p => p.PerKilometerAmount).Name("Bedrag per kilometer");
            Map(p => p.MaxAmount).Name("Max bedrag");
        }
    }
}
