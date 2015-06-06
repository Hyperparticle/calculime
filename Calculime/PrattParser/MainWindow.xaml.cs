using System.Windows;
using PrattParser.Parsers;

namespace PrattParser
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
