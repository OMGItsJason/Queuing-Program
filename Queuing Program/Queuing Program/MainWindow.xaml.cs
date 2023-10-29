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

namespace Queuing_Program
{

    public partial class MainWindow : Window
    {
        private CashierClass _cashier;
        string nextCustomer;
        private CashierWindowQueueForm cwf;
        public MainWindow()
        {
            InitializeComponent();
            _cashier = new CashierClass();
            CashierWindowQueueForm cwf = new CashierWindowQueueForm();
            cwf.Show();
        }
        private void btnCashier_Click(object sender, RoutedEventArgs e)
        {
                lblQueue.Text = _cashier.CashierGenerateNumber("P - ");
                CashierClass.getNumberInQueue = lblQueue.Text;
                CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);

        }

    }

}
