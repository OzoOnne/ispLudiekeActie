using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DonationManager
    {

        public decimal GetTotalDonations()
        {
            return GetSingleDonations() + GetPerKilometerDonations();
        }
        public decimal GetPerKilometerDonations()
        {
            return Random.Shared.Next(1, 10);
        }
        private decimal GetSingleDonations()
        {
            return Random.Shared.Next(1, 100);
        }
    }
}
