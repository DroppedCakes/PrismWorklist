using System.Windows;
using System.Windows.Controls;

namespace PrismWorkList.WorkSpace.Views
{
    /// <summary>
    /// Interaction logic for Navigator
    /// </summary>
    public partial class NavigatorView : UserControl
    {
        public NavigatorView()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
