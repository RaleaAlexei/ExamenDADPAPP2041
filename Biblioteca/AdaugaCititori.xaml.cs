using Biblioteca.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Biblioteca
{
    public partial class AdaugaCititori : Window
    {
        private BibliotecaContext dbContext;
        private Cititori cititori;

        public AdaugaCititori()
        {
            InitializeComponent();
            dbContext = new BibliotecaContext();
            cititori = new Cititori();
            LoadCartiInchiriate();
        }

        private void BtnSalveaza_Click(object sender, RoutedEventArgs e)
        {
            cititori.NumeCititor = txtNume.Text;
            cititori.DateChirie = dpDataChiriei.SelectedDate ?? DateTime.Now;

            dbContext.Cititori.Add(cititori);
            dbContext.SaveChanges();
            Close();
        }

        private void BtnAnuleaza_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadCartiInchiriate()
        {
            var cartiInchiriate = dbContext.Carti.ToList();
            lbCartiInchiriate.ItemsSource = cartiInchiriate;
        }

        private void BtnAdaugaCarti_Click(object sender, RoutedEventArgs e)
        {
            var selectedBooks = lbCartiInchiriate.SelectedItems.Cast<Carti>().ToList();
            foreach (var book in selectedBooks)
            {
                cititori.Carti.Add(book);
            }
        }
    }
}
