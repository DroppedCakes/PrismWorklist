using MahApps.Metro.Controls;
using NLog;
using System.Windows;

namespace PrismWorkList.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        /// <summary>
        /// logger
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

    }
}
