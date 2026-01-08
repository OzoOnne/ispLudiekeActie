using Logic;



DonationManager donationManager = new DonationManager();
List<DonationModel> donationLines = donationManager.getDonationLines();

Console.WriteLine("Donation Lines:");

foreach (DonationModel line in donationLines)
{
        Console.WriteLine($"Per kilometer {line.PerKilometerAmount}, MaxAmount: {line.MaxAmount}");
}

donationManager.SetKilometers(50);

Console.WriteLine($"Total per kilometer donations for 50 km: {donationManager.GetTotalDonations()}");

donationManager.SetKilometers(600);

Console.WriteLine($"Total per kilometer donations for 600 km: {donationManager.GetTotalDonations()}");

donationManager.SetDayDonations(300);

Console.WriteLine($"Total donations with day donations of 300: {donationManager.GetTotalDonations()}");
