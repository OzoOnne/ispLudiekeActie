using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DonationManager
    {

        public decimal GetTotalDonations()
        {
            return Random.Shared.Next(1000, 10000);
        }
        public decimal GetPerKilometerDonations()
        {
            return Random.Shared.Next(1, 10);
        }
    }
}
