using Microsoft.Extensions.DependencyInjection;

namespace SueldoHoras3381027
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Sueldo());
        }
    }
}