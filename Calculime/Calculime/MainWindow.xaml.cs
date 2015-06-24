﻿using System;
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
        public static readonly bool Debug = true;

        private readonly Brush _background;

        private readonly Parser _parser = new MathParser();
        

        public MainWindow()
        {
            InitializeComponent();

            _background = InputTextBox.Background;

            //var url = new Uri("C:/Users/Dan/OneDrive/Creations/Coding/Visual Studio/Calculime/Calculime/MathJax/sample-dynamic.html");
            //Browser.Navigate(url);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
			Calculate(true);
            InputTextBox.Focus();
        }

		private void InputTextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				Calculate(true);
			}
		}

        /// <summary>
        /// Attempts to execute the parsed expression and outputs 
        /// the result.
        /// </summary>
        /// <param name="output">Whether or not the result is initiated</param>
		private void Calculate(bool output)
		{
            InputTextBox.Background = _background;
		    var expression = InputTextBox.Text;

		    if (string.IsNullOrWhiteSpace(expression))
		    {
		        InputTextBox.Text = "";
		        OutputTextBlock.Text = Symbol.Zero.ToString();
		        return;
		    }

		    try
		    {
		        var result = _parser.Execute(expression);

                OutputTextBlock.Text = result.ToString();

		        if (!output) return;
                Memory.AddResult(result);
		        HistoryListView.Items.Add(
		            new HistoryItem { Expression = expression, Result = OutputTextBlock.Text });

                Calculate(false); // Recalculate the result
		    }
		    catch (Exception e)
		    {
		        if (Debug)
		        {
                    Console.WriteLine(e.Message);
                    DebugLabel.Content = e.Message;
		        }
                    
		        InputTextBox.Background = Brushes.Firebrick;
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
                InputTextBox.Text += Symbol.Period;
				

		    InputTextBox.Focus();
		}

		private void OperationButton_Click(object sender, RoutedEventArgs e)
		{
            var source = e.Source;

			if (source.Equals(MultiplyButton))
				InputTextBox.Text += Symbol.Asterisk;
			else if (source.Equals(DivideButton))
				InputTextBox.Text += Symbol.Slash;
			else if (source.Equals(AddButton))
				InputTextBox.Text += Symbol.Plus;
			else if (source.Equals(SubtractButton))
				InputTextBox.Text += Symbol.Minus;
			else if (source.Equals(ExponentButton))
				InputTextBox.Text += Symbol.Caret;

            InputTextBox.Focus();
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
