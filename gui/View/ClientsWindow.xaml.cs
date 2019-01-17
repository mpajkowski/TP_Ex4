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
using app.ViewModel;

namespace app.View
{
    /// <summary>
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        public ClientsWindow(MainWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            CreateNewClientWindow = null;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (CreateNewClientWindow != null)
            {
                e.Cancel = true;
                return;
            }

            parent.ClientsWindow = null;
            base.OnClosing(e);
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (CreateNewClientWindow == null)
            {
                CreateNewClientWindow = new CreateNewClientWindow(this);
                CreateNewClientWindow.Show();
            }
        }

        private MainWindow parent;
        public CreateNewClientWindow CreateNewClientWindow { get; set; }
    }
}
