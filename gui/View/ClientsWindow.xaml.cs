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
        public ClientsWindow(Window1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            CreateNewClientWindow = null;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

        private Window1 parent;
        public CreateNewClientWindow CreateNewClientWindow { get; set; }
    }
}
