using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ExpressionParser _parser;

        public MainWindow()
        {
            _parser = new ExpressionParser();

            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
			Calculate(true);
            InputTextBox.Focus();
        }

		private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
		    var keyPressed = e.Key;

			if (keyPressed == Key.Enter)
			{
				Calculate(true);
			}
		}

		private void Calculate(bool showHistory)
		{
			var expression = InputTextBox.Text;

		    try
		    {
		        var result = _parser.Parse(expression);
                OutputTextBlock.Text = result;
		        InputTextBox.Background = SystemColors.WindowBrush;
                
                if (showHistory)
                {
                    HistoryListView.Items.Add(new HistoryItem { Expression = expression, Result = OutputTextBlock.Text });
                }
		    }
		    catch (Exception e)
		    {
		        InputTextBox.Background = Brushes.IndianRed;
		    }
		}

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text = "";

            InputTextBox.Focus();
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			var text = InputTextBox.Text;

			InputTextBox.Text = text.Substring(0, text.Length - 1);

            InputTextBox.Focus();
		}

		private void NumberButton_Click(object sender, RoutedEventArgs e)
		{
		    var source = e.Source;

			if (source.Equals(ZeroButton))
				InputTextBox.Text += 0;
			else if (source.Equals(OneButton))
				InputTextBox.Text += 1;
			else if (source.Equals(TwoButton))
				InputTextBox.Text += 2;
			else if (source.Equals(ThreeButton))
				InputTextBox.Text += 3;
			else if (source.Equals(FourButton))
				InputTextBox.Text += 4;
			else if (source.Equals(FiveButton))
				InputTextBox.Text += 5;
			else if (source.Equals(SixButton))
				InputTextBox.Text += 6;
			else if (source.Equals(SevenButton))
				InputTextBox.Text += 7;
			else if (source.Equals(EightButton))
				InputTextBox.Text += 8;
			else if (source.Equals(NineButton))
				InputTextBox.Text += 9;
			else if (source.Equals(DecimalButton))
				InputTextBox.Text += '.';

		    InputTextBox.Focus();
		}

		private void OperationButton_Click(object sender, RoutedEventArgs e)
		{
            var source = e.Source;

			if (source.Equals(MultiplyButton))
				InputTextBox.Text += '*';
			else if (source.Equals(DivideButton))
				InputTextBox.Text += '/';
			else if (source.Equals(AddButton))
				InputTextBox.Text += '+';
			else if (source.Equals(SubtractButton))
				InputTextBox.Text += '-';
			else if (source.Equals(PowerButton))
				InputTextBox.Text += '^';

            InputTextBox.Focus();
		}

        private void InputTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate(false);
        }
    }

	public class HistoryItem
	{
		public string Expression { get; set; }
        public string Result { get; set; }
	}
}
