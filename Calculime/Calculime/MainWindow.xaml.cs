#define DEBUG

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PrattParser;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace Calculime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Brush _background;

        private readonly Parser _parser = new MathParser();
        private readonly MathFormatter _formatter = new MathFormatter();

        private int _caretPos;  // TODO: Get the caret in the correct position

        public MainWindow()
        {
            InitializeComponent();

            _background = InputTextBox.Background;

            //var url = new Uri("C:/Users/Dan/OneDrive/Creations/Coding/Visual Studio/Calculime/Calculime/MathJax/sample-dynamic.html");
            //Browser.Navigate(url);

            Calculate(false);
            FocusText();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
			Calculate(true);
            FocusText();
        }

		private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
		    if (e.Key == Key.Enter)
		    {
		        Calculate(true);
		    }
		}

        private void InputTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Remove characters from right to left if the caret is at the beginning
		    if (e.Key == Key.Back && InputTextBox.CaretIndex == 0 && string.IsNullOrEmpty(InputTextBox.SelectedText) && !string.IsNullOrEmpty(InputTextBox.Text))
		            InputTextBox.Text = InputTextBox.Text.Remove(0, 1);
        }

        /// <summary>
        /// Attempts to execute the parsed expression and outputs 
        /// the result.
        /// </summary>
        /// <param name="output">Whether or not the result is initiated</param>
		private void Calculate(bool output)
        {
            InputTextBox.Background = _background;

            var expression = InputFormattedTextBox.Text = _formatter.Format(InputTextBox.Text);

		    if (expression.Equals(Symbol.Empty))
		    {
		        OutputTextBox.Text = Symbol.Zero.ToString();
		        return;
		    }

		    try
		    {
		        var result = _parser.Execute(expression);

                OutputTextBox.Text = result.ToString();

		        if (!output) return;
                Memory.AddResult(result);
		        HistoryListView.Items.Add(
		            new HistoryItem { Expression = expression, Result = OutputTextBox.Text });

                Calculate(false); // Recalculate the result
		    }
		    catch (Exception e)
		    {
#if (DEBUG)
                Console.WriteLine(e.Message);
                DebugLabel.Content = e.Message;
#endif
		        InputTextBox.Background = Brushes.Firebrick;
		    }
		}

        private void FocusText()
        {
            if (InputTextBox.IsFocused) return;

            var index = InputTextBox.CaretIndex;
            InputTextBox.Focus();
            InputTextBox.CaretIndex = index;
        }

        private void PutText(string s)
        {
            InputTextBox.Text = InputTextBox.Text.Insert(InputTextBox.CaretIndex, s);
        }

		private void ClearButton_Click(object sender, RoutedEventArgs e)
		{
			InputTextBox.Text = "";

            FocusText();
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			var text = InputTextBox.Text;

		    if (!string.IsNullOrEmpty(text))
                InputTextBox.Text = text.Substring(0, text.Length - 1);
		}

		private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(ZeroButton))
				InputTextBox.Text += 0;
            else if (sender.Equals(OneButton))
				InputTextBox.Text += 1;
            else if (sender.Equals(TwoButton))
				InputTextBox.Text += 2;
            else if (sender.Equals(ThreeButton))
				InputTextBox.Text += 3;
            else if (sender.Equals(FourButton))
				InputTextBox.Text += 4;
            else if (sender.Equals(FiveButton))
				InputTextBox.Text += 5;
            else if (sender.Equals(SixButton))
				InputTextBox.Text += 6;
            else if (sender.Equals(SevenButton))
				InputTextBox.Text += 7;
            else if (sender.Equals(EightButton))
				InputTextBox.Text += 8;
            else if (sender.Equals(NineButton))
			    InputTextBox.Text += 9;
            else if (sender.Equals(DecimalButton))
                InputTextBox.Text += Symbol.Period;
				
		    FocusText();
		}

		private void OperationButton_Click(object sender, RoutedEventArgs e)
		{
			if (sender.Equals(MultiplyButton))
				InputTextBox.Text += Symbol.Asterisk;
            else if (sender.Equals(DivideButton))
				InputTextBox.Text += Symbol.Slash;
            else if (sender.Equals(AddButton))
				InputTextBox.Text += Symbol.Plus;
            else if (sender.Equals(SubtractButton))
				InputTextBox.Text += Symbol.Minus;
            else if (sender.Equals(ExponentButton))
				InputTextBox.Text += Symbol.Caret;

            FocusText();
		}

        private void InputTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate(false);
        }

        private void TitleBar_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

	public class HistoryItem
	{
		public string Expression { get; set; }
        public string Result { get; set; }
	}
}
