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
using System.Drawing; // Icon

namespace GameDaemon
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        //private System.ComponentModel.IContainer components;

        public MainWindow()
        {
            InitializeComponent();
            //this.components = new System.ComponentModel.Container();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu1
            this.contextMenu1.MenuItems.AddRange(
                        new System.Windows.Forms.MenuItem[] { this.menuItem1 });

            // Initialize menuItem1
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "E&xit";
            //this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);

            // Set up how the form should be displayed.
           // this.ClientSize = new System.Drawing.Size(292, 266);
            //this.Text = "Notify Icon Example";

            // Create the NotifyIcon.

            this.notifyIcon = new NotifyIcon();
            this.notifyIcon.BalloonTipText = "Hello, NotifyIcon!";
            this.notifyIcon.Text = "I'm the Dragon Warrior!";
            notifyIcon.Icon = new Icon("res/panda.ico");

            // The ContextMenu property sets the menu that will
            // appear when the systray icon is right clicked.
            notifyIcon.ContextMenu = this.contextMenu1;

            // The Text property sets the text that will be displayed,
            // in a tooltip, when the mouse hovers over the systray icon.
            notifyIcon.Visible = true;

            //this.notifyIcon.Icon = new System.Drawing.Icon("NotifyIcon.ico");
            this.notifyIcon.Visible = true;
            //notifyIcon.MouseDoubleClick += OnNotifyIconDoubleClick;
            this.notifyIcon.ShowBalloonTip(1000);      
        }

        private void onWindowClosed(object sender, EventArgs e)
        {
            this.notifyIcon.Dispose();
        }
    }
}
