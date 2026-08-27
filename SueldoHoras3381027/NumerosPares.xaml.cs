namespace SueldoHoras3381027;

public partial class NumerosPares : ContentPage
{
	public NumerosPares()
	{
		InitializeComponent();
	}
    private void MostrarPares_Clicked(object sender, EventArgs e)
    {
        string numerosPares = "";

        for (int i = 0; i <= 100; i += 2)
        {
            numerosPares += i + " ";
        }

        ResultadoLabel.Text = numerosPares;
    }
}