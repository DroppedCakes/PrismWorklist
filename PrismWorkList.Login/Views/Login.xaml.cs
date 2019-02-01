using System.Windows;
using System.Windows.Controls;

namespace PrismWorkList.Login.Views
{
    /// <summary>
    /// Interaction logic for Login
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
    }
}
