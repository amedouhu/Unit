using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit
{
    public partial class Unit : Form
    {
        /* Unitフォームクラス */

        private Object obj = new object();
        public TcpClient client = null;

        public Unit()
        {
            /* コンストラクタ */
            InitializeComponent();
        }

        ~Unit()
        {
            /* デストラクタ */
            disconnect();
        }

        public void print(string message)
        {
            /* チャットに出力する */
            if (String.IsNullOrWhiteSpace(message))
            {
                // メッセージが空白なら
                return;
            }
            if (this.InvokeRequired)
            {
                // Invokeが必要なら
                Invoke((Action)(() =>
                {
                    tb_chat.Text += "\r\n" + message;
                    tb_chat.SelectionStart = tb_chat.Text.Length;
                    tb_chat.Focus();
                    tb_chat.ScrollToCaret();
                }));
            }else
            {
                // Invokeが必要でないなら
                tb_chat.Text += "\r\n" + message;
                tb_chat.SelectionStart = tb_chat.Text.Length;
                tb_chat.Focus();
                tb_chat.ScrollToCaret();
            }
        }

        public void position(String position)
        {
            /* ポジションを設定する */
            if (this.InvokeRequired)
            {
                // Invokeが必要なら
                Invoke((Action)(() =>
                {
                    lb_position.Text = "@" + position;
                }));
            }
            else
            {
                // Invokeが必要でないなら
                lb_position.Text = "@" + position;
            }
        }

        public void connect(String address, int port)
        {
            /* サーバーとの接続処理 */
            try
            {
                // サーバーとの接続を試みる
                if (client != null)
                {
                    // 既にサーバーに接続しているなら
                    disconnect();
                }
                lock (obj)
                {
                    client = new TcpClient(address, port);
                }
                position(address + ":" + port);
                print("Connected to the server.");
            }catch (Exception e)
            {
                // サーバーとの接続に失敗したなら
                print("Failed to connect to the server.: " + e.Message);
            }
        }

        public void disconnect()
        {
            /* サーバーとの切断処理 */
            try
            {
                // サーバーとの接続を試みる
                if (client == null)
                {
                    // サーバーとの接続がないなら
                    return;
                }
                client.Close();
                client = null;
                position("Home");
                print("Disconnected from the server.");
            }catch (Exception e)
            {
                // サーバーとの切断に失敗したなら
                print("Failed to disconnect from the server.: " + e.Message);
            }
        }

        public void recvData()
        {
            /* データの受信処理 */
            Task.Run(() =>
            {
                while (true)
                {
                    lock (obj)
                    {
                        if (client == null)
                        {
                            // サーバーとの接続がないなら
                            position("Home");
                            return;
                        }
                        try
                        {
                            var data = new byte[256];
                            int size = 0;
                            string resultMessage = "";
                            var stream = client.GetStream();
                            while (true)
                            {
                                if (! stream.DataAvailable)
                                {
                                    // 読み取るデータがないなら
                                    break;
                                }
                                size = stream.Read(data, 0, data.Length);
                                if (size == 0)
                                {
                                    // 全てのデータを読み取ったなら
                                    break;
                                }
                                resultMessage += System.Text.Encoding.UTF8.GetString(data, 0, size);
                                System.Threading.Thread.Sleep(1);
                            }
                            if (resultMessage == "")
                            {
                                // データが空白なら
                                continue;
                            }
                            print(resultMessage);
                        }
                        catch (Exception e)
                        {
                            if (client == null)
                            {
                                // サーバーとの切断による例外なら
                                position("Home");
                                return;
                            }
                            if (! client.Connected)
                            {
                                // サーバーとの接続の実態がないなら

                                position("Home");
                                client = null;
                            }
                            print("Failed to receive data.: " + e.Message);
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(1);
                }
            });
        }

        public void sendData(String message)
        {
            /* データの送信処理 */
            try
            {
                // データの送信を試みる
                lock (obj)
                {
                    if (client == null)
                    {
                        // サーバーに接続されていないなら
                        position("Home");
                        return;
                    }
                    if (String.IsNullOrWhiteSpace(message))
                    {
                        // メッセージが空白なら
                        return;
                    }
                    var data = System.Text.Encoding.UTF8.GetBytes(message);
                    var stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                }
            }catch (Exception e)
            {
                // データの送信に失敗したなら
                print("Failed to send data.: " + e.Message);
            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            /* bt_sendがクリックされたとき */
            if (String.IsNullOrWhiteSpace(tb_message.Text))
            {
                // メッセージが空白なら
                return;
            }
            if (client == null)
            {
                // サーバーとの接続がないなら
                position("Home");
                print("You are at Home.");
            }else
            {
                // サーバーとの接続があるなら
                sendData(tb_message.Text);
            }
            tb_message.Text = "";
        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            /* bt_connectがクリックされたとき */
            var connect = new Connect();
            connect.Owner = this;
            connect.ShowDialog();
        }

        private void bt_host_Click(object sender, EventArgs e)
        {
            /* bt_hostがクリックされたとき */
            var host = new Host();
            host.Owner = this;
            host.ShowDialog();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            /* bt_closeがクリックされたとき */
            this.Close();
        }
    }
}
