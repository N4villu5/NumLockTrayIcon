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

        private static readonly Icon lockedIcon = Properties.Resources.locked_icon;
        private static readonly Icon unlockedIcon = Properties.Resources.unlocked_icon;

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
            trayIcon.Dispose();
            Application.Exit();
        }

        private Icon GetIcon()
        {
            return numLockState ? lockedIcon : unlockedIcon;
        }
        
        private bool GetNumLockState()
        {
            return Control.IsKeyLocked(Keys.NumLock);
        }

    }
}
