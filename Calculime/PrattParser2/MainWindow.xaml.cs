using System.Windows;
using PrattParser2.Parsers;

namespace PrattParser2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ParseTest.Parse();
        }
    }
}
