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
using System.Threading;

namespace PI_App {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    class Data {
        public static List<double> data = new List<double>();
        public static List<Thread> threads = new List<Thread>();
    }

    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            while (true) {
                Data.threads.Add(new Thread(ThreadProc));
                Data.threads.Last().Start();
            }
        }

        public void ThreadProc(object stateInfo) {
            Random random = new Random();
            while (true) {
                Data.data.Add(Calc(Calc(random.NextDouble(), random.NextDouble()), Calc(random.NextDouble(), random.NextDouble())));
            }
        }

        private double Calc(double x, double y) {
            return Math.Sin(x % y);
        }
    }
}
