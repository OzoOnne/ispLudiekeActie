using System.ComponentModel;
using System.Runtime.CompilerServices;
using Logic;

namespace LudiekeActieISP
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        // ... (je andere variabelen: _opgeslagenKilometers etc. blijven hier staan) ...
        private decimal _opgeslagenKilometers = 0;
        private decimal _opgeslagenDagDonaties = 0;

        // NIEUW: Variabele voor zichtbaarheid
        private bool _isInputVisible;

        // ... (je data properties blijven hier staan) ...
        private decimal _bedragPerKm;
        private decimal _totaalGedoneerd;
        private decimal _dagDonaties;
        private decimal _gefietsteKilometers;
        private string _inputKilometers;
        private string _inputDagDonaties;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Standaard verbergen we de invoer (False)
            IsInputVisible = false;

            laadData();
        }

        // NIEUW: Property die regelt of het blok zichtbaar is
        public bool IsInputVisible
        {
            get => _isInputVisible;
            set
            {
                _isInputVisible = value;
                OnPropertyChanged();
            }
        }

        // ... (De rest van je properties blijven hetzelfde: BedragPerKm, etc.) ...
        public decimal BedragPerKm { get => _bedragPerKm; set { _bedragPerKm = value; OnPropertyChanged(); } }
        public decimal TotaalGedoneerd { get => _totaalGedoneerd; set { _totaalGedoneerd = value; OnPropertyChanged(); } }
        public decimal DagDonaties { get => _dagDonaties; set { _dagDonaties = value; OnPropertyChanged(); } }
        public decimal GefietsteKilometers { get => _gefietsteKilometers; set { _gefietsteKilometers = value; OnPropertyChanged(); } }
        public string InputKilometers { get => _inputKilometers; set { _inputKilometers = value; OnPropertyChanged(); } }
        public string InputDagDonaties { get => _inputDagDonaties; set { _inputDagDonaties = value; OnPropertyChanged(); } }


        // NIEUW: De methode die wordt uitgevoerd als je op het LOGO klikt
        private void OnLogoClicked(object sender, EventArgs e)
        {
            // Draai de waarde om: als hij aan staat -> uit, als hij uit staat -> aan
            IsInputVisible = !IsInputVisible;
        }

        // ... (Je Button_Clicked en laadData methodes blijven precies zoals ze waren) ...
        private void Button_Clicked(object sender, EventArgs e)
        {
            decimal nieuweKm = 0;
            decimal nieuweDonatie = 0;
            decimal.TryParse(InputKilometers, out nieuweKm);
            string dagInputClean = InputDagDonaties?.Replace('.', ',');
            decimal.TryParse(dagInputClean, out nieuweDonatie);

            _opgeslagenKilometers += nieuweKm;
            _opgeslagenDagDonaties += nieuweDonatie;

            laadData();

            InputKilometers = string.Empty;
            InputDagDonaties = string.Empty;

            // OPTIONEEL: Verberg het menu weer direct na het klikken op 'Berekenen'
            // IsInputVisible = false; 
        }

        private void laadData()
        {
            DonationManager manager = new DonationManager();
            manager.SetKilometers(_opgeslagenKilometers);
            manager.SetDayDonations(_opgeslagenDagDonaties);

            BedragPerKm = manager.GetStaticRatePerKm();
            GefietsteKilometers = _opgeslagenKilometers;
            DagDonaties = _opgeslagenDagDonaties;
            TotaalGedoneerd = manager.GetTotalDonations();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}