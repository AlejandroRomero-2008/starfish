namespace SueldoHoras3381027;

public partial class Sueldo : ContentPage
{
	public Sueldo()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		double hora = Convert.ToDouble(Horas.Text);
		double pagohora = Convert.ToDouble(Pagohora.Text);

		double resul = hora * pagohora;

		await DisplayAlert("Resultado",$"Tu ganaste en tu semana: {resul}","OK");
    }
}