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
        BindingList<GPU> gpuCollection = new BindingList<GPU>();        

        public MainWindow()
        {
            InitializeComponent();
            Timer tim = new Timer(1000);
            tim.Elapsed += T_Elapsed;

            tim.Start();
            lstListings.DataContext = gpuCollection;
            gpuCollection.AllowEdit = true;
            gpuCollection.AddingNew += GpuCollection_AddingNew;
            gpuCollection.ListChanged += GpuCollection_ListChanged;
        }

        private void GpuCollection_ListChanged(object sender, ListChangedEventArgs e)
        {
            lstListings.DataContext = null;
            lstListings.DataContext = gpuCollection;
        }

        private void GpuCollection_AddingNew(object sender, AddingNewEventArgs e)
        {
            lstListings.DataContext = null;
            lstListings.DataContext = gpuCollection;
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            changeValues();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            gpuCollection.Add(new GPU("www.google.pt", "GTX 1080Ti", "349€", "Out of Stock"));
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
                r = new Random(DateTime.Now.Millisecond);
                int value = r.Next();
                gpuCollection[i].price = Convert.ToString(value) + "€";
            }
        }
    }
}
