using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using app.Model;
using services;

namespace app.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClientsWindow = null;
            DogsWindow = null;
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsWindow == null)
            {
                ClientsWindow = new ClientsWindow(this);
                ClientsWindow.Show();
            }
        }

        private void DogsButton_Click(object sender, RoutedEventArgs e)
        {
            if (DogsWindow == null)
            {
                DogsWindow = new DogsWindow(this);
                DogsWindow.Show();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (ClientsWindow != null || DogsWindow != null)
            {
                e.Cancel = true;
                return;
            }

            base.OnClosing(e);
        }

        public ClientsWindow ClientsWindow { get; set; }
        public DogsWindow DogsWindow { get; set; }
    }
}
