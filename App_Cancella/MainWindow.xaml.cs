using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace App_Cancella
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //bool stop = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        CancellationTokenSource ct;

        private void Btn_Start1_Click(object sender, RoutedEventArgs e)
        {
            if (ct == null)
                ct = new CancellationTokenSource();
            //if (stop)
            //    stop = false;
            Task.Factory.StartNew(() => DoWork(100, 1000, lbl_Count1, ct));
        }

        private void Btn_Start2_Click(object sender, RoutedEventArgs e)
        {
            if (ct == null)
                ct = new CancellationTokenSource();
            //if (stop)
            //    stop = false;
            int max = Convert.ToInt32(txt_Max1.Text);
            Task.Factory.StartNew(() => DoWork(max, 1000, lbl_Count2, ct));
        }

        private void Btn_Start3_Click(object sender, RoutedEventArgs e)
        {
            if (ct == null)
                ct = new CancellationTokenSource();
            //if (stop)
            //    stop = false;
            int max = Convert.ToInt32(txt_Max2.Text);
            int delay = Convert.ToInt32(txt_Delay.Text);
            Task.Factory.StartNew(() => DoWork(max, delay, lbl_Count3, ct));
        }

        private void DoWork(int max, int delay, Label lbl, CancellationTokenSource ct)
        {
            for (int i = 0; i <= max; i++)
            {
                Dispatcher.Invoke(() => UpdateUI(i, lbl));
                Thread.Sleep(delay);

                if (ct.Token.IsCancellationRequested)
                    break; //gracefully

                //if (stop)
                //    break;
            }
        }

        private void UpdateUI(int i, Label lbl)
        {
            lbl.Content = i.ToString();
        }

        private void Btn_Stop_Click(object sender, RoutedEventArgs e)
        {
            if (ct != null)
            {
                ct.Cancel();
                ct = null;
            }

        }
    }
}
