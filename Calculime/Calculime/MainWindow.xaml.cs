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

			OutputTextBlock.Text = parser.Parse(expression);
			HistoryListView.Items.Add(new HistoryItem { Id = expression + '=' + OutputTextBlock.Text});
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text = "";
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			string text = InputTextBox.Text;

			InputTextBox.Text = text.Substring(0, text.Length - 1);
		}

		private void NumberButton_Click(object sender, RoutedEventArgs e)
		{
			if (e.Source == ZeroButton)
				InputTextBox.Text += 0;
			else if (e.Source == OneButton)
				InputTextBox.Text += 1;
			else if (e.Source == TwoButton)
				InputTextBox.Text += 2;
			else if (e.Source == ThreeButton)
				InputTextBox.Text += 3;
			else if (e.Source == FourButton)
				InputTextBox.Text += 4;
			else if (e.Source == FiveButton)
				InputTextBox.Text += 5;
			else if (e.Source == SixButton)
				InputTextBox.Text += 6;
			else if (e.Source == SevenButton)
				InputTextBox.Text += 7;
			else if (e.Source == EightButton)
				InputTextBox.Text += 8;
			else if (e.Source == NineButton)
				InputTextBox.Text += 9;
			else if (e.Source == DecimalButton)
				InputTextBox.Text += '.';
		}

		private void OperationButton_Click(object sender, RoutedEventArgs e)
		{
			if (e.Source == MultiplyButton)
				InputTextBox.Text += '*';
			else if (e.Source == DivideButton)
				InputTextBox.Text += '/';
			else if (e.Source == AddButton)
				InputTextBox.Text += '+';
			else if (e.Source == SubtractButton)
				InputTextBox.Text += '-';
			else if (e.Source == PowerButton)
				InputTextBox.Text += '^';
		}
    }

	public class HistoryItem
	{
		public string Id { get; set; }
	}
}
