using IgraPamcenja.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace IgraPamcenja
{
    public partial class MainWindow : Window
    {
        private GameController gameController;
        private DispatcherTimer timer;
        private int secondsElapsed = 0;

        public MainWindow()
        {
            InitializeComponent();

            gameController = new();

            foreach (Button button in fieldsGrid.Children.OfType<Button>())
            {
                button.IsEnabled = false;
                button.Background = Brushes.White;
            }

            timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(.1)
            };

            timer.Tick += (object sender, EventArgs e) =>
            {
                secondsElapsed++;
                tbTime.Text = (secondsElapsed / 10F).ToString("0.0s");
            };
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            gameController.InitializeGame();
            btnEnd.IsEnabled = true;
            btnStart.IsEnabled = false;

            foreach (Button button in fieldsGrid.Children.OfType<Button>())
            {
                button.Content = "?";
                button.IsEnabled = true;
                button.Background = Brushes.White;
            }

            secondsElapsed = 0;
            timer.Start();
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            EndGame();
        }

        private void EndGame()
        {
            btnEnd.IsEnabled = false;
            btnStart.IsEnabled = true;

            foreach (Button button in fieldsGrid.Children.OfType<Button>())
            {
                button.IsEnabled = false;
            }
        }

        private async void HandleResponse(int fieldClickedIndex, ActionResponse response)
        {
            if (response.Type.Equals(ResponseType.FIRST_FIELD_SELECTED))
            {
                var button = fieldsGrid.Children.OfType<Button>().ElementAt((int)response.FieldIndex1);
                button.Background = Brushes.Gray;
                button.Content = response.FieldValue1;
            }
            else if (response.Type.Equals(ResponseType.MATCHING))
            {
                var button1 = fieldsGrid.Children.OfType<Button>().ElementAt((int)response.FieldIndex1);
                button1.Background = Brushes.Green;
                button1.Content = response.FieldValue1;

                var button2 = fieldsGrid.Children.OfType<Button>().ElementAt((int)response.FieldIndex2);
                button2.Background = Brushes.Green;
                button2.Content = response.FieldValue2;
            }
            else if (response.Type.Equals(ResponseType.NOT_MATCHING))
            {
                var button1 = fieldsGrid.Children.OfType<Button>().ElementAt((int)response.FieldIndex1);
                button1.Background = Brushes.Red;
                button1.Content = response.FieldValue1;

                var button2 = fieldsGrid.Children.OfType<Button>().ElementAt((int)response.FieldIndex2);
                button2.Background = Brushes.Red;
                button2.Content = response.FieldValue2;

                await Task.Delay(500);

                button1.Background = Brushes.White;
                button1.Content = "?";

                button2.Background = Brushes.White;
                button2.Content = "?";
            }
            else if (response.Type.Equals(ResponseType.GAME_ENDED))
            {
                timer.Stop();
                MessageBox.Show("Cestitamo! Uspesno ste zavrsili igru.");
                EndGame();
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(0);
            if (response != null)
                HandleResponse(0, response);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(1);
            if (response != null)
                HandleResponse(1, response);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(2);
            if (response != null)
                HandleResponse(2, response);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(3);
            if (response != null)
                HandleResponse(3, response);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(4);
            if (response != null)
                HandleResponse(4, response);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(5);
            if (response != null)
                HandleResponse(5, response);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(6);
            if (response != null)
                HandleResponse(6, response);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(7);
            if (response != null)
                HandleResponse(7, response);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(8);
            if (response != null)
                HandleResponse(8, response);
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(9);
            if (response != null)
                HandleResponse(9, response);
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(10);
            if (response != null)
                HandleResponse(10, response);
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(11);
            if (response != null)
                HandleResponse(11, response);
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(12);
            if (response != null)
                HandleResponse(12, response);
        }

        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(13);
            if (response != null)
                HandleResponse(13, response);
        }

        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(14);
            if (response != null)
                HandleResponse(14, response);
        }

        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(15);
            if (response != null)
                HandleResponse(15, response);
        }

        private void btn17_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(16);
            if (response != null)
                HandleResponse(16, response);
        }

        private void btn18_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(17);
            if (response != null)
                HandleResponse(17, response);
        }

        private void btn19_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(18);
            if (response != null)
                HandleResponse(18, response);
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            var response = gameController.FieldClicked(19);
            if (response != null)
                HandleResponse(19, response);
        }
    }
}
