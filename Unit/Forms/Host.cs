using System;
using System.Windows.Forms;

namespace Unit
{
    public partial class Host : Form
    {
        /* Hostフォームクラス */

        public Host()
        {
            /* コンストラクタ */
            InitializeComponent();
        }

        private void bt_host_Click(object sender, EventArgs e)
        {
            /* bt_hostがクリックされたとき */
            if (tb_port.Text == "")
            {
                // 入力情報が完全ではないなら
                lb_error.Text = "The input information is not complete.";
                return;
            }
            if (! int.TryParse(tb_port.Text, out int result))
            {
                // ポート番号をint型に変換できないなら
                lb_error.Text = "The port number must be of type int.";
                return;

            }
            if (!(0 <= int.Parse(tb_port.Text) && int.Parse(tb_port.Text) <= 65535))
            {
                // ポート番号が範囲を超えているなら
                lb_error.Text = "The port number must be in the range 0~65535.";
                return;
            }
            lb_error.Text = "";
            var server = new Server();
            server.Owner = this.Owner;
            server.Show();
            server.beggin(int.Parse(tb_port.Text));
            server.recvData();
            this.Close();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            /* bt_closeがクリックされたとき */
            this.Close();
        }
    }
}
