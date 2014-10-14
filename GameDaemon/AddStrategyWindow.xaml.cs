using GameDaemon.Item;
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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace GameDaemon
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class AddStrategyWindow : Window
    {
        Target t;
        public ActionItem NewItem { get; set; }
        public AddStrategyWindow(Target t)
        {
            this.t = t;
            InitializeComponent();
            starttime.Value = DateTime.Now;
            endtime.Value = DateTime.Now;
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            esc();
        }

        private void esc()
        {
            this.DialogResult = false;
            this.Close();
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            ok();
        }

        private void ok()
        {
            if (starttime.Value == null || endtime.Value == null)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show("时间不能为空！", "Warning");
            }
            else
            {
                DateTime sdt = starttime.Value.Value;
                DateTime edt = endtime.Value.Value;
                ActionItem item = new ActionItem(0,sdt.Hour, sdt.Minute, edt.Hour, edt.Minute);
                item.TargetId = t.Id;
                t.DaemonStrategy.addStrategy(item);
                NewItem = item;
                this.DialogResult = true;
                Close();
            }        
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ok();
            }
            else if (e.Key == Key.Escape)
            {
                esc();
            }
        }
    }
}
