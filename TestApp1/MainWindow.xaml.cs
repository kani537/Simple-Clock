using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace TestApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new();
        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            _timer.Start();
        }

        private void InitializeTimer()
        {
            // イベント発生間隔の設定
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            byte alpha, red, green, blue;
            alpha = 0xFF;
            red = 0xFF;
            green = 0x80;
            blue = 0x80;

            // イベント登録
            _timer.Tick += (_, _) =>
            {
                alpha = 0xFF;
                if (red == 0xFF && green != 0xFF)
                {
                    green++;
                }
                else if (green == 0xFF && red != 0x80)
                {
                    red --;
                }
                else if (green == 0xFF && blue == 0xFF)
                {
                    blue ++;
                }
                else if (blue == 0xFF && green != 0x80)
                {
                    green --;
                }
                else if (blue == 0xFF && red != 0xFF)
                {
                    red ++;
                }
                else if (red == 0xFF && blue != 0x80)
                {
                    blue --;
                }
                else
                {
                    red ++;
                }
                TimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
                TimeLabel.Foreground = new SolidColorBrush(Color.FromArgb(alpha, red, green, blue));
                TimeWindow.Background = new SolidColorBrush(Color.FromArgb((byte)0x60, (byte)(0xFF-red), (byte)(0xFF - green), (byte)(0xFF - blue)));
            };
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseMenu_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ResetSize_Click(object sender, RoutedEventArgs e)
        {
            TimeWindow.WindowState = WindowState.Normal;
            TimeWindow.Height = 100;
            TimeWindow.Width = 200;
        }

        private void MaxSize_Click(object sender, RoutedEventArgs e)
        {
            TimeWindow.WindowState = WindowState.Maximized;
        }
    }
}
