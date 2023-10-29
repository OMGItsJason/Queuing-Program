using System;
using System.Collections;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Queuing_Program
{
    public partial class CashierWindowQueueForm : Window
    {
        private DispatcherTimer timer;
        private CustomerView customerView;

        public CashierWindowQueueForm()
        {
            InitializeComponent();
            DisplayCashierQueue(CashierClass.CashierQueue);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();

            customerView = new CustomerView();
            customerView.Show();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
            if (CashierClass.CashierQueue.Count == 0)
            {
                MessageBox.Show("Queue Is Empty");
            }
            else
            {
                string peekItem = CashierClass.CashierQueue.Peek();
                customerView.UpdateDisplayedItem(peekItem);
            }
        }


        private void timer_tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (CashierClass.CashierQueue.Count == 0)
            {
                MessageBox.Show("Nothing Is In Queue");
            }
            else
            {
                CashierClass.CashierQueue.Dequeue();
            }
        }

        public void DisplayCashierQueue (IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach(Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

    }
}
