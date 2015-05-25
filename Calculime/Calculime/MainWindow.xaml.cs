using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExpressionParser parser;

        public MainWindow()
        {
            parser = new ExpressionParser();

            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
			Calculate();
        }

		private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Calculate();
			}
		}

		private void Calculate()
		{
			string expression = InputTextBox.Text;

			HistoryListView.Items.Add(new MyItem { Id = expression });
			OutputTextBlock.Text = parser.Parse(expression);
		}

		public class MyItem
		{
			public string Id { get; set; }
		}

		private void HistoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}
    }
}
