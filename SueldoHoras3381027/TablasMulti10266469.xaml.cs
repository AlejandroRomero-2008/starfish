using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SueldoHoras3381027;

public partial class TablasMulti10266469 : ContentPage
{
    public class Tabla
    {
        public string Titulo { get; set; }
        public string Lineas { get; set; }
    }

    // Lista completa de todas las tablas (1 al 10)
    private List<Tabla> _todasLasTablas;

    // Lista de CheckBox para acceder fácilmente
    private List<CheckBox> _checkBoxes;


    public TablasMulti10266469()
	{
		InitializeComponent();

        // Crear la lista de CheckBox según los nombres definidos en XAML
        _checkBoxes = new List<CheckBox>
        {
            chk1, chk2, chk3, chk4, chk5,
            chk6, chk7, chk8, chk9, chk10
        };

        // Generar todas las tablas
        _todasLasTablas = GenerarTablas(1, 10);

        // Al iniciar, mostramos todas
        TablasCollectionView.ItemsSource = _todasLasTablas;
    }

    // Método que genera una lista de tablas desde 'inicio' hasta 'fin'
    private List<Tabla> GenerarTablas(int inicio, int fin)
    {
        var tablas = new List<Tabla>();

        for (int i = inicio; i <= fin; i++)
        {
            var lineas = new StringBuilder();
            for (int j = 1; j <= 10; j++)
            {
                lineas.AppendLine($"{i} x {j} = {i * j}");
            }

            tablas.Add(new Tabla
            {
                Titulo = $"Tabla del {i}",
                Lineas = lineas.ToString()
            });
        }

        return tablas;
    }

    // Evento del botón "Mostrar todas"
    private void OnMostrarTodasClicked(object sender, EventArgs e)
    {
        TablasCollectionView.ItemsSource = _todasLasTablas;
    }

    // Evento del botón "Mostrar seleccionadas"
    private void OnMostrarSeleccionadasClicked(object sender, EventArgs e)
    {
        // Obtener los números marcados
        var numerosSeleccionados = new List<int>();

        for (int i = 0; i < _checkBoxes.Count; i++)
        {
            if (_checkBoxes[i].IsChecked)
            {
                numerosSeleccionados.Add(i + 1); // +1 porque los índices van de 0 a 9
            }
        }

        // Si no hay ninguno seleccionado, mostrar lista vacía
        if (numerosSeleccionados.Count == 0)
        {
            TablasCollectionView.ItemsSource = new List<Tabla>();
            return;
        }

        // Filtrar las tablas que correspondan a los números seleccionados
        var tablasFiltradas = _todasLasTablas
            .Where((tabla, index) => numerosSeleccionados.Contains(index + 1))
            .ToList();

        TablasCollectionView.ItemsSource = tablasFiltradas;
    }

}
