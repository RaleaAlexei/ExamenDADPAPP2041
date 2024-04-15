using Biblioteca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Biblioteca
{
    /// <summary>
    /// Interaction logic for AdaugaCarte.xaml
    /// </summary>
    public partial class AdaugaCarte : Window
    {
        private BibliotecaContext dbContext;
        public AdaugaCarte()
        {
            InitializeComponent();
            dbContext = new BibliotecaContext();
        }
        private void BtnSalveaza_Click(object sender, RoutedEventArgs e)
        {
            Carti carti = new Carti
            {
                DenumireCarte = txtDenumire.Text,
                NumeAutor = txtAutor.Text,
                PretCarte = double.Parse(txtPret.Text),
                DataEditarii = dpDataEditarii.SelectedDate ?? DateTime.Now
            };
            dbContext.Carti.Add(carti);
            dbContext.SaveChanges();
            Close();
        }

        private void BtnAnuleaza_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
