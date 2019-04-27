using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumLockTrayIcon
{
    public class NumLockApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private bool numLockState;

        public NumLockApplicationContext()
        {
            numLockState = GetNumLockState();
            trayIcon = new NotifyIcon()
            {
                Icon = GetIcon(),
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };
        }

        public async Task UpdateIconAsync()
        {
            while (true)
            {
                if (numLockState != GetNumLockState())
                {
                    numLockState = !numLockState;
                    trayIcon.Icon = GetIcon();
                }
                await Task.Delay(1000);
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private Icon GetIcon()
        {
            return numLockState ? Properties.Resources.locked_icon : Properties.Resources.unlocked_icon;
        }
        
        private bool GetNumLockState()
        {
            return Control.IsKeyLocked(Keys.NumLock);
        }

    }
}
