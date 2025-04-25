using Microsoft.Maui;

namespace GorselProgOdev2;

public partial class BMI : ContentPage
{
    public BMI()
    {
        InitializeComponent();

        
        KiloSlider.Value = 0;
        BoySlider.Value = 0;

        
    }

    private void OnSliderChanged(object sender, ValueChangedEventArgs e)
    {
        
        KiloGirdisi.Text = ((int)KiloSlider.Value).ToString();
        BoyGirdisi.Text = ((int)BoySlider.Value).ToString();
        
    }

    private void OnEntryChanged(object sender, TextChangedEventArgs e)
    {
        
        if (double.TryParse(KiloGirdisi.Text, out double kilo))
            KiloSlider.Value = Math.Clamp(kilo, KiloSlider.Minimum, KiloSlider.Maximum);

        if (double.TryParse(BoyGirdisi.Text, out double boy))
            BoySlider.Value = Math.Clamp(boy, BoySlider.Minimum, BoySlider.Maximum);

        
    }

    

    private void VkiHesapla(object sender, EventArgs e)
    {
        if (double.TryParse(KiloGirdisi.Text, out double kilo) && double.TryParse(BoyGirdisi.Text, out double boy) && boy > 0)
        {
            boy = boy / 100.0;
            double vki = kilo / (boy * boy);
            VkiLabel.Text = vki.ToString("F2");
            KategoriLabel.Text = $"Kategoriniz: {VkiKategorisiniGetir(vki)}";
        }
        else
        {
            VkiLabel.Text = "Hatalý Giriþ!";
            KategoriLabel.Text = "Lütfen geçerli bir kilo ve boy giriniz!";
        }
    }

    private string VkiKategorisiniGetir(double vki)
    {
        if (vki < 16)
            return "Ýleri Düzeyde Zayýf";
        else if (vki < 17)
            return "Orta Düzeyde Zayýf";
        else if (vki < 18.5)
            return "Hafif Düzeyde Zayýf";
        else if (vki < 25)
            return "Normal Kilolu";
        else if (vki < 30)
            return "Hafif Þiþman / Fazla Kilolu";
        else if (vki < 35)
            return "1. Derecede Obez";
        else if (vki < 40)
            return "2. Derecede Obez";
        else
            return "3. Derecede Obez / Morbid Obez";
    }
}
