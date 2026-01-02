using CsvHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class DonationManager
    {
        private decimal _dayDonations;
        private decimal _kilometers;

        public decimal GetTotalDonations()
        {
            return _dayDonations + GetSingleDonations() + GetPerKilometerDonations();
        }
        public decimal GetPerKilometerDonations()
        {
            return Random.Shared.Next(1, 10);
        }
        public void SetDayDonations(decimal amount)
        { 
            _dayDonations = amount;
        }
        public void SetKilometers(decimal kilometers)
        {
            _kilometers = kilometers;
        }
        private decimal GetSingleDonations()
        {
            return Random.Shared.Next(1, 100);
        }
    }
}
