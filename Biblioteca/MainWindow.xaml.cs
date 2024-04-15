using Biblioteca.Classes;
using System.Collections.ObjectModel;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BibliotecaContext dbContext;
        private ObservableCollection<Carti> CartiCollection;
        private ObservableCollection<Cititori> CititoriCollection;
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new BibliotecaContext();
            CartiCollection = new ObservableCollection<Carti>(dbContext.Carti);
            CititoriCollection = new ObservableCollection<Cititori>(dbContext.Cititori);
            dgCarti.ItemsSource = CartiCollection;
            dgCititori.ItemsSource = CititoriCollection;
        }
        private void AdaugaCartiCommand_Executed(object sender, RoutedEventArgs e)
        {
            AdaugaCarte wind = new AdaugaCarte();
            wind.ShowDialog();
            CartiCollection.Clear();
            foreach (var carti in dbContext.Carti)
            {
                CartiCollection.Add(carti);
            }
        }
        private void AdaugaCititoriCommand_Executed(object sender, RoutedEventArgs e)
        {
            AdaugaCititori wind = new AdaugaCititori();
            wind.ShowDialog();
            CititoriCollection.Clear();
            foreach (var cititori in dbContext.Cititori)
            {
                CititoriCollection.Add(cititori);
            }
        }
        private void Interogare1_Click(object sender, RoutedEventArgs e)
        {
            var queryResult = dbContext.Cititori
                .OrderBy(c => c.NumeCititor)
                .Select(c => new
                {
                    NumeCititor = c.NumeCititor,
                    CartiInchiriate = string.Join(", ", c.Carti.Select(carti => carti.DenumireCarte))
                })
                .ToList();

            StringBuilder resultBuilder = new StringBuilder();
            foreach (var item in queryResult)
            {
                resultBuilder.AppendLine($"Nume Cititor: {item.NumeCititor}, Carti Inchiriate: {item.CartiInchiriate}");
            }

            MessageBox.Show(resultBuilder.ToString(), "Interogare a");
        }

        private void Interogare2_Click(object sender, RoutedEventArgs e)
        {
            var queryResult = dbContext.Carti
                .Where(c => c.DataEditarii.Year == 2022 && c.NumeAutor.StartsWith('A'))
                .ToList();

            StringBuilder resultBuilder = new StringBuilder();
            foreach (var item in queryResult)
            {
                resultBuilder.AppendLine($"Denumire Carte: {item.DenumireCarte}, Nume Autor: {item.NumeAutor}, Pret Carte: {item.PretCarte}");
            }

            MessageBox.Show(resultBuilder.ToString(), "Interogare b");
        }
    }
}