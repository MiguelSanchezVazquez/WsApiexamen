using ApiExamen;
using BdiExamen.Dtos;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfExamen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Agregar_Click(object sender, RoutedEventArgs e)
        {
            bool isWs = CheckBoxWS.IsChecked ?? false;
            tbResponse.Text = string.Empty;

            int idExamen = int.Parse(tbIdExamen.Text);
            string nombre = tbNombre.Text;
            string descripcion = tbDescripcion.Text;

            ClsExamen.CallWebService(isWs);

            var response = await ClsExamen.AgregarExamenAsync(new ExamenDto
            {
                idExamen = idExamen,
                Descripcion = descripcion,
                Nombre = nombre
            });

            tbResponse.Text = response.Message;
        }

        private async void Button_Actualizar_Click(object sender, RoutedEventArgs e)
        {
            bool isWs = CheckBoxWS.IsChecked ?? false;
            tbResponse.Text = string.Empty;

            int idExamen = int.Parse(tbIdExamen.Text);
            string nombre = tbNombre.Text;
            string descripcion = tbDescripcion.Text;

            ClsExamen.CallWebService(isWs);

            var response = await ClsExamen.ActualizarExamenAsync(new ExamenDto
            {
                idExamen = idExamen,
                Descripcion = descripcion,
                Nombre = nombre
            });

            tbResponse.Text = response.Message;
        }

        private async void Button_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            bool isWs = CheckBoxWS.IsChecked ?? false;
            tbResponse.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbDescripcion.Text = string.Empty;

            int idExamen = int.Parse(tbIdExamen.Text);

            ClsExamen.CallWebService(isWs);

            var response = await ClsExamen.EliminarExamenAsync(idExamen);

            tbResponse.Text = response.Message;
        }

        private async void Button_Consultar_Click(object sender, RoutedEventArgs e)
        {
            bool isWs = CheckBoxWS.IsChecked ?? false;
            tbResponse.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbDescripcion.Text = string.Empty;

            int idExamen = int.Parse(tbIdExamen.Text);

            ClsExamen.CallWebService(isWs);

            var response = await ClsExamen.ConsultarExamenAsync(idExamen);

            if (response != null && response.Success)
            {
                tbNombre.Text = response.Examen.Nombre;
                tbDescripcion.Text = response.Examen.Descripcion;
            }

            tbResponse.Text = response.Message;
        }
    }
}