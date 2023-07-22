using System;
using System.Windows.Forms;

namespace Unit
{
    public partial class Connect : Form
    {
        /* Connectフォームクラス */

        public Connect()
        {
            /* コンストラクタ */
            InitializeComponent();
        }

        private void bt_connect_disconnect_Click(object sender, EventArgs e)
        {
            /* bt_connect_disconnectがクリックされたとき */
            var unit = ((Unit)Application.OpenForms["Unit"]);
            if (unit.client == null)
            {
                // サーバーとの接続がないなら
                if (tb_address.Text == "" || tb_port.Text == "")
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
                if (! (0 <= int.Parse(tb_port.Text) && int.Parse(tb_port.Text) <= 65535))
                {
                    // ポート番号が範囲を超えているなら
                    lb_error.Text = "The port number must be in the range 0~65535.";
                    return;
                }
                unit.connect(tb_address.Text, int.Parse(tb_port.Text));
                unit.recvData();
            }
            else
            {
                // サーバーとの接続があるなら
                unit.disconnect();
            }
            this.Close();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            /* bt_closeがクリックされたとき */
            this.Close();
        }
    }
}
