using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class DonationModel
    {
        public bool IsPerKilometerDonation { get; set; }
        public decimal PerKilometerAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public decimal SingleDonationAmount { get; set; }
    }
}
