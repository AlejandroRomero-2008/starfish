namespace SueldoHoras3381027;

public partial class Langostaahumada6439059 : ContentPage
{
    private bool _isAnimating = true;

    // Forzamos la cultura de EE. UU. para asegurar el formato en Dólares ($95.00)
    private readonly CultureInfo _dollarCulture = new CultureInfo("en-US");
    public Langostaahumada6439059()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _isAnimating = true;
        IniciarAnimacionFondo();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _isAnimating = false;
    }

    private async void IniciarAnimacionFondo()
    {
        while (_isAnimating)
        {
            await AnimatedBg.TranslateTo(-25, -25, 4000, Easing.SinInOut);
            await AnimatedBg.ScaleTo(1.1, 3000, Easing.SinInOut);
            await AnimatedBg.TranslateTo(25, 25, 4000, Easing.SinInOut);
            await AnimatedBg.ScaleTo(1.0, 3000, Easing.SinInOut);
        }
    }

    private void OnCalcularClicked(object sender, EventArgs e)
    {
        if (int.TryParse(TxtPersonas.Text, out int personas) && personas > 0)
        {
            (decimal costoPlatillo, string categoria) = personas switch
            {
                <= 200 => (95.00m, "Tarifa Estándar"),
                <= 300 => (85.00m, "Descuento Preferencial"),
                _ => (75.00m, "Tarifa Especial Gran Evento")
            };

            decimal total = personas * costoPlatillo;

            // Al pasar _dollarCulture se fuerza el símbolo de dólar $ y separación por puntos
            LblPersonasCount.Text = personas.ToString("N0", _dollarCulture);
            LblCostoPlatillo.Text = costoPlatillo.ToString("C2", _dollarCulture);
            LblCategoria.Text = categoria;
            LblTotal.Text = total.ToString("C2", _dollarCulture);

            ResultCard.IsVisible = true;
        }
        else
        {
            DisplayAlert("Entrada Inválida", "Por favor, ingrese un número válido de personas mayor a 0.", "OK");
        }
    }
}
