using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unit
{
    public partial class Server : Form
    {
        /* Serverフォームクラス */

        private Object obj = new object();
        private TcpListener listener = null;
        private List<TcpClient> clients = new List<TcpClient>();

        public Server()
        {
            /* コンストラクタ */
            InitializeComponent();
        }

        ~Server()
        {
            /* デストラクタ */
            end();
        }

        public void beggin(int port)
        {
            /* サーバーを開始する */
            this.Text = "Server(" + port + ")";
            print("Hosted the server on port " + port + ".");
            lock (obj)
            {
                try
                {
                    // リスナーの開始を試みる
                    listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                    listener.Start();
                }
                catch(Exception e)
                {
                    // リスナーの開始に失敗したなら
                    print("Failed to start listener.: " + e.Message);
                }
            }
            // クライアントからの接続を待機
            Task.Run(() =>
            {
                while (listener != null)
                {
                    if (listener == null)
                    {
                        // サーバーが停止しているなら
                        return;
                    }
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        clients.Add(client);
                        print(client.Client.RemoteEndPoint + " connected.");
                    }
                    catch
                    {
                        print("client connect error.");
                    }
                }
            });
        }

        public void end()
        {
            /* サーバーを停止する */
            sendData("Server closed.");
            lock (obj)
            {
                if (listener == null)
                {
                    // サーバーが停止しているなら
                    return;
                }
                // クライアントを切断する
                foreach (TcpClient client in clients)
                {
                    try
                    {
                        client.Close();
                    }catch (Exception e) {
                        print("Client disconnect failed.: " + e.Message);
                    }
                }
                clients.Clear();
                // サーバーを終了させる
                listener.Stop();
                listener = null;
            }
        }

        public void recvData()
        {
            /* クライアントからデータを受信する */
            Task.Run(() =>
            {
                while (true)
                {
                    lock (obj)
                    {
                        if (listener == null)
                        {
                            // サーバーが停止しているなら
                            return;
                        }
                        foreach (TcpClient client in clients)
                        {
                            try
                            {
                                var data = new byte[256];
                                int size = 0;
                                string resultMessage = "";
                                var stream = client.GetStream();
                                while (true)
                                {
                                    if (!stream.DataAvailable)
                                    {
                                        // 読み取るデータがないなら
                                        break;
                                    }
                                    size = stream.Read(data, 0, data.Length);
                                    if (size <= 0)
                                    {
                                        // 読み取りが終わっているなら
                                        break;
                                    }
                                    resultMessage += System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                                    if (resultMessage == "")
                                    {
                                        // データが空白なら
                                        break;
                                    }
                                    resultMessage = DateTime.Now.ToString("HH:mm ") + client.Client.RemoteEndPoint + ": " + resultMessage;
                                    sendData(resultMessage);
                                    print(resultMessage);
                                    System.Threading.Thread.Sleep(1);
                                }
                            }
                            catch (Exception e)
                            {
                                print("Failed to receive from client.: " + e.Message);
                            }
                        }
                        for (int i = clients.Count - 1; i >= 0; i--)
                        {
                            if (! clients[i].Connected)
                            {
                                // クライアントが接続されていないなら
                                TcpClient client = listener.AcceptTcpClient();
                                print(client + " disconnected.");
                                clients.RemoveAt(i);
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(1);
                }
            });
        }

        public void sendData(string message)
        {
            /* クライアントにデータを送信する */
            lock (obj)
            {
                if (listener == null)
                {
                    // サーバーが停止しているなら
                    return;
                }
                foreach (TcpClient client in clients)
                {
                    try
                    {
                        var data = System.Text.Encoding.UTF8.GetBytes(message);
                        var stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                    }catch (Exception e)
                    {
                        print("Failed to send data to client.: " + e.Message);
                    }
                }
            }
        }

        public void print(String message)
        {
            /* チャットに出力する */
            if (this.InvokeRequired)
            {
                // Invokeが必要なら
                try
                {
                    Invoke((Action)(() =>
                    {
                        tb_log.Text += "\r\n" + message;
                        tb_log.SelectionStart = tb_log.Text.Length;
                        tb_log.Focus();
                        tb_log.ScrollToCaret();
                    }));
                }
                catch
                {
                    print("print error.");
                }
            }
            else
            {
                // Invokeが必要でないなら
                tb_log.Text += "\r\n" + message;
                tb_log.SelectionStart = tb_log.Text.Length;
                tb_log.Focus();
                tb_log.ScrollToCaret();
            }   
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* FormClosingイベントが発生したなら */
            end();
        }
    }
}
