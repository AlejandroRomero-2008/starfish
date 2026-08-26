namespace SueldoHoras3381027;

public partial class CuentaRegresiva20253446 : ContentPage
{
    const int NumeroInicial = 10;

    int numeroActual;
    IDispatcherTimer timer;

    public CuentaRegresiva20253446()
	{
		InitializeComponent();

        timer = Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer_Tick;

        ReiniciarContador();
    }

    void ReiniciarContador()
    {
        timer.Stop();

        numeroActual = NumeroInicial;
        LblNumero.Text = numeroActual.ToString();

        BtnIniciar.IsEnabled = true;
    }

    void Timer_Tick(object sender, EventArgs e)
    {
        numeroActual--;

        if (numeroActual <= 0)
        {
            timer.Stop();
            LblNumero.Text = "¡Listo!";
            BtnIniciar.IsEnabled = true;
            return;
        }

        LblNumero.Text = numeroActual.ToString();
    }

    private void BtnIniciar_Clicked(object sender, EventArgs e)
    {
        numeroActual = NumeroInicial;
        LblNumero.Text = numeroActual.ToString();

        BtnIniciar.IsEnabled = false;
        timer.Start();
    }

    private void BtnReiniciar_Clicked(object sender, EventArgs e)
    {
        ReiniciarContador();
    }
}