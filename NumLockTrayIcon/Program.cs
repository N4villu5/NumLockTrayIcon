using System;
using System.Threading.Tasks;
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

            NumLockApplicationContext ctx = new NumLockApplicationContext();

            Task.Run(() => ctx.UpdateIconAsync());

            Application.Run(ctx);
        }
    }
}
