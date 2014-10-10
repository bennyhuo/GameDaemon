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

namespace GameDaemon
{
    /// <summary>
    /// AddTargetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddTargetWindow : Window
    {
        public AddTargetWindow()
        {
            InitializeComponent();
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
            if (!targetName.Text.Equals(""))
            {
                Controller.getInstance().addTarget(new Target(targetName.Text));
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("程序名不能为空！", "错误");
            }
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ok();
            }
            else if(e.Key ==Key.Escape)
            {
                esc();
            }
        }
    }
}
