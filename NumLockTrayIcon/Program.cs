using System;
using System.Drawing;
using System.Windows.Forms;

namespace NumLockTrayIcon
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new NumLockApplicationContext());
        }
    }

    public class NumLockApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        public NumLockApplicationContext()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = GetIcon(),
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };
        }

        private Icon GetIcon()
        {
            return Control.IsKeyLocked(Keys.NumLock) ? Properties.Resources.locked_icon : Properties.Resources.unlocked_icon;
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
