using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatYearXAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBlock ResultTextBox;
        private TextBox InputCatYear;
        public MainWindow()
        {
            InitializeComponent();
            ResultTextBox = new TextBlock()
            {
                FontSize = 18,
                Text = "Your cat is: "
            };
            InputCatYear = new TextBox()
            {
                TextAlignment = TextAlignment.Center,
                FontSize = 18,
                Margin = new Thickness(12, 5, 0, 2),
                Width = 120,                
            };
            InputCatYear.KeyDown += InputKeyDown;

            TextBlock question = new TextBlock()
            {
                Text = "How old is your cat?(Year)",
                FontSize = 18,
            };

            StackPanel horizontalSP = new StackPanel() { Orientation=Orientation.Horizontal , Margin = new Thickness(1,5,0,0) };
            horizontalSP.Children.Add(question);
            horizontalSP.Children.Add(InputCatYear);

            StackPanel mainVertical = new StackPanel( );
            mainVertical.Children.Add(horizontalSP);
            mainVertical.Children.Add(ResultTextBox);

            CatWindow.Content = mainVertical;
           
        }

        private void InputKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    int age = int.Parse(InputCatYear.Text);
                    string resultHumanAge = string.Empty;
                    if(age >= 0 && age <= 1 ) 
                    {
                        resultHumanAge = "0-15";
                        ResultTextBox.Text = resultHumanAge + " years old.";
                    }
                    else if(age >=2 && age < 25)
                    {
                        resultHumanAge = (((age-2)*4)+24).ToString();
                        ResultTextBox.Text = resultHumanAge + " years old.";
                    }

                }catch(Exception ex) {
                    MessageBox.Show("Something wrong, seem like the value in the field is invalid number. "+ ex.Message);
                }
            }
        }
    }
}
