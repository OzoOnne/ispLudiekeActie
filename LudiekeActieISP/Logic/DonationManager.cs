using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Logic.Resources;

namespace Logic
{
    public class DonationManager
    {
        private readonly string _filePath;

        private decimal _dayDonations;
        private decimal _kilometers;

        public DonationManager()
        {
            _dayDonations = 0;
            _kilometers = 0;


            _filePath = Path.Combine(AppContext.BaseDirectory, "Resources", "Donaties.csv");
        }

        public decimal GetTotalDonations()
        {
            return _dayDonations + GetPerKilometerDonations();
        }
        public decimal GetPerKilometerDonations()
        {
            List<DonationModel> donationLines = getDonationLines();
            decimal donationTotal = 0;
            foreach (DonationModel donation in donationLines)
            {
                donationTotal += GetDonationAmount(donation);
            }
            return donationTotal;
        }
        private decimal GetDonationAmount(DonationModel donation)
        {
            decimal donationAmount = donation.PerKilometerAmount * _kilometers;
            if (donation.MaxAmount == 0)
            {
                return donationAmount;
            }
            if (donationAmount > donation.MaxAmount)
            {
                donationAmount = donation.MaxAmount;
            }
            return donationAmount;
        }
        public void SetDayDonations(decimal amount)
        {
            _dayDonations = amount;
        }
        public void SetKilometers(decimal kilometers)
        {
            _kilometers = kilometers;
        }

        public List<DonationModel> getDonationLines()
        {
            if (!File.Exists(_filePath))
            {
                return new List<DonationModel>();
            }

            using var reader = new StreamReader(_filePath);

            var dutch = CultureInfo.GetCultureInfo("nl-NL");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HeaderValidated = null,    // turn off header validation
                MissingFieldFound = null,  // ignore missing fields
                TrimOptions = TrimOptions.Trim
            };

            using var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<DonationMap>();

            return csv.GetRecords<DonationModel>().ToList();
        }
    }
}
