namespace SueldoHoras3381027;

public partial class ConversorNadi : ContentPage
{
	public ConversorNadi()
	{
		InitializeComponent();
	}
    private async void OnCalcularClicked(object sender, EventArgs e)
    {
        // 1. Micro-animación en el botón al tocarlo (Usando ScaleToAsync)
        await BtnCalcular.ScaleToAsync(0.95, 80, Easing.CubicOut);
        await BtnCalcular.ScaleToAsync(1.0, 80, Easing.CubicIn);

        // 2. Validación fluida
        if (!double.TryParse(TxtPesos.Text, out double pesos) || pesos <= 0)
        {
            await MostrarError("Ingresa un monto en pesos válido.");
            return;
        }

        if (!double.TryParse(TxtTipoCambio.Text, out double tipoCambio) || tipoCambio <= 0)
        {
            await MostrarError("El tipo de cambio debe ser mayor a 0.");
            return;
        }

        // 3. Cálculo de la divisa
        double dolares = pesos / tipoCambio;

        // 4. Actualizar textos
        LblDolares.Text = $"{dolares:C2} USD";
        LblDetalle.Text = $"Con un presupuesto de {pesos:C2} MXN\na una tasa de {tipoCambio:F2} MXN/USD";

        // 5. Animación para revelar la tarjeta de resultado (Usando FadeToAsync y ScaleToAsync)
        CardResultado.Opacity = 0;
        CardResultado.Scale = 0.7;

        await Task.WhenAll(
            CardResultado.FadeToAsync(1, 350, Easing.CubicOut),
            CardResultado.ScaleToAsync(1.0, 500, Easing.SpringOut)
        );
    }

    private async Task MostrarError(string mensaje)
    {
        LblDolares.Text = "$0.00 USD";
        LblDetalle.Text = mensaje;
        CardResultado.Opacity = 1;

        // Efecto Shake con TranslateToAsync
        uint timeout = 50;
        await CardResultado.TranslateToAsync(-10, 0, timeout);
        await CardResultado.TranslateToAsync(10, 0, timeout);
        await CardResultado.TranslateToAsync(-5, 0, timeout);
        await CardResultado.TranslateToAsync(5, 0, timeout);
        await CardResultado.TranslateToAsync(0, 0, timeout);
    }
}