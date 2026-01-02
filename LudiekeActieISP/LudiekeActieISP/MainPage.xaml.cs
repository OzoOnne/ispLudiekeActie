using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic;
namespace LudiekeActieISP
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private decimal _bedragPerKm;
        private decimal _totaalGedoneerd;
        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            laadData();
        }

        public decimal BedragPerKm
        {
            get => _bedragPerKm;
            set
            {
                _bedragPerKm = value;
                OnPropertyChanged();
            }
        }

        public decimal TotaalGedoneerd
        {
            get => _totaalGedoneerd;
            set
            {
                _totaalGedoneerd = value;
                OnPropertyChanged();
            }
        }

        private void laadData()
        {
            DonationManager manager = new DonationManager();

            BedragPerKm = manager.GetPerKilometerDonations();
            TotaalGedoneerd = manager.GetTotalDonations();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
