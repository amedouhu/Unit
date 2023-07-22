using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit
{
    internal static class Program
    {
        /* メインエントリポイント */
        [STAThread]
        static void Main()
        {
            // Unitフォームを表示する
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Unit());
        }
    }
}
