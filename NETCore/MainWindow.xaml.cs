using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace NETCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<GPU> gpuCollection = new ObservableCollection<GPU>();

        public MainWindow()
        {
            InitializeComponent();
            Timer tim = new Timer(1000);
            tim.Elapsed += T_Elapsed;

            tim.Start();
            lstListings.ItemsSource = gpuCollection;
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            changeValues();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            gpuCollection.Add(new GPU("www.google.pt", "GTX 1080Ti", "349€", "Out of Stock"));
            gpuCollection.Add(new GPU("https://github.com/Fody/Fody", "GTX 1080Ti", "349€", "Out of Stock"));

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if(gpuCollection.Count > 0)
                gpuCollection.Remove(gpuCollection.Last());
        }

        void changeValues()
        {
            Random r;
            for (int i = 0; i < gpuCollection.Count; i++)
            {
                r = new Random();
                int value = r.Next();
                gpuCollection[i].price = Convert.ToString(value) + "€";

                Random t = new Random();
                int newValue = t.Next(0, 2);
                gpuCollection[i].availability = newValue == 0 ? "Out Of Stock" : "In Stock";
            }
        }

        private void lstListings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", !((GPU)lstListings.SelectedItem).url.Contains("http") ?
                ("https://" + ((GPU)lstListings.SelectedItem).url) : ((GPU)lstListings.SelectedItem).url);
        }
    }
}
