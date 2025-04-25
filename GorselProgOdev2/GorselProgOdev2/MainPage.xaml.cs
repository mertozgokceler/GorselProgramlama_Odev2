namespace GorselProgOdev2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNavigateToBMI(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new BMI());
        }

        private async void OnNavigateToKrediHesaplama(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new Kredi());
        }

        private async void OnNavigateToRenkSecme(object sender, EventArgs e) 
        {
            await Navigation.PushAsync(new RenkSecme());
        }

        
    }

}
