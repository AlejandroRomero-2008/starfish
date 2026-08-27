namespace SueldoHoras3381027;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}
    private async void ConversorNadi_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ConversorNadi());
    }

    private async void CuentaRegresiva_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CuentaRegresiva20253446());
    }

    private async void LangostaAhumada_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Langostaahumada6439059());
    }

    private async void NumerosPares_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NumerosPares());
    }

    private async void Sueldo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sueldo());
    }

    private async void TablasMulti_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TablasMulti10266469());
    }
}