
using System;

namespace GorselProgOdev2
{
    public partial class Kredi : ContentPage
    {
        public Kredi()
        {
            InitializeComponent();
        }

      
        private async void KrediT�r�Se�Butonu_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayActionSheet("Kredi T�r� Se�in", "�ptal", null, "�htiya� Kredisi", "Konut Kredisi", "Ta��t Kredisi", "Ticari Kredi");

            if (!string.IsNullOrEmpty(result) && result != "�ptal")
            {
                KrediT�r�Se�Butonu.Text = result;
            }
        }

       
        private void LoanTermSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int selectedTerm = (int)e.NewValue;
            TermLabel.Text = $"{selectedTerm} Ay";
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            try
            {
                
                double krediTutar� = double.Parse(LoanAmountEntry.Text);
                double faizOran� = double.Parse(InterestRateEntry.Text) / 100;
                int vadeS�resi = int.Parse(TermLabel.Text.Replace(" Ay", ""));

               
                double kdv = 0, bsmv = 0;

                if (KrediT�r�Se�Butonu.Text == "�htiya� Kredisi")
                {
                    kdv = 0.15;
                    bsmv = 0.10;
                }
                else if (KrediT�r�Se�Butonu.Text == "Konut Kredisi")
                {
                    kdv = 0;
                    bsmv = 0;
                }
                else if (KrediT�r�Se�Butonu.Text == "Ta��t Kredisi")
                {
                    kdv = 0.15;
                    bsmv = 0.05;
                }
                else if (KrediT�r�Se�Butonu.Text == "Ticari Kredi")
                {
                    kdv = 0;
                    bsmv = 0.05;
                }

               
                double brutFaiz = ((faizOran� + (faizOran� * bsmv) + (faizOran� * kdv)) / 100);
                double taksit = ((Math.Pow(1 + brutFaiz, vadeS�resi) * brutFaiz) / (Math.Pow(1 + brutFaiz, vadeS�resi) - 1)) * krediTutar�;
                double toplam�deme = taksit * vadeS�resi;
                double toplamFaiz = toplam�deme - krediTutar�;

                
                MonthlyPaymentLabel.Text = $"{taksit:F2} TL";
                TotalPaymentLabel.Text = $"{toplam�deme:F2} TL";
                TotalInterestLabel.Text = $"{toplamFaiz:F2} TL";
            }
            catch (Exception)
            {
                
                DisplayAlert("Hata", "L�tfen t�m alanlar� do�ru �ekilde doldurun.", "Tamam");
            }
        }
    }

}