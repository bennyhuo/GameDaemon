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

using System.Windows.Forms; // NotifyIcon control
using System.Drawing;
using GameDaemon.Dao; // Icon

namespace GameDaemon
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu notifyMenu;
        private System.Windows.Forms.MenuItem[] notifyMenuItems;
        //private System.ComponentModel.IContainer components;

        public MainWindow()
        {
            InitializeComponent();
            buildNotifyIcon();           
        }

        

        private void onWindowClosed(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
        }

        private void buildNotifyIcon()
        {
            buildNotifyIconMenu();

            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.BalloonTipText = "Hello, NotifyIcon!";
            this.notifyIcon.Text = "I'm the Dragon Warrior!";
            this.notifyIcon.Icon = new Icon("res/panda.ico");

            this.notifyIcon.ContextMenu = this.notifyMenu;
            
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += OnNotifyIconClick;
            this.notifyIcon.ShowBalloonTip(1000);      
        }


        bool isHidden = false;
        
        private void OnNotifyIconClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {

            if (this.isHidden)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
            this.isHidden = !this.isHidden;
        }

        
        
        private void buildNotifyIconMenu()
        {
            this.notifyMenu = new System.Windows.Forms.ContextMenu();
            this.notifyMenuItems = new System.Windows.Forms.MenuItem[2];
            
            // Initialize menuItem1
            System.Windows.Forms.MenuItem exitItem = new System.Windows.Forms.MenuItem();
            this.notifyMenuItems[0] = exitItem;
            exitItem.Index = 0;
            exitItem.Text = "E&xit";
            exitItem.Click += new System.EventHandler(this.exit);

            System.Windows.Forms.MenuItem editItem = new System.Windows.Forms.MenuItem();
            this.notifyMenuItems[1] = editItem;
            editItem.Index = 1;
            editItem.Text = "E&dit";
            //editItem.Click += new System.EventHandler(this.exit);

            this.notifyMenu.MenuItems.AddRange(this.notifyMenuItems);
        }

        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void onSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine(this.WindowState);
        }

        private void onButtonClick(object sender, RoutedEventArgs e)
        {
            DbConnection conn = DbConnection.getInstance();
        }
    }
}
