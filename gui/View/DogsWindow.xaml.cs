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
    /// Interaction logic for DogsWindow.xaml
    /// </summary>
    public partial class DogsWindow : Window
    {
        public DogsWindow(Window1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            parent.DogsWindow = null;
            base.OnClosing(e);
        }

        private Window1 parent;
    }
}
