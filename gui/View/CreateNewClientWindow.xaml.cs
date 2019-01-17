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

namespace app.View
{
    /// <summary>
    /// Interaction logic for CreateNewClient.xaml
    /// </summary>
    public partial class CreateNewClientWindow : Window
    {
        public CreateNewClientWindow(ClientsWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private ClientsWindow parent;

        protected override void OnClosing(CancelEventArgs e)
        {
            parent.CreateNewClientWindow = null;
            base.OnClosing(e);
        }
    }
}
