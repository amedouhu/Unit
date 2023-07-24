using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            sendData("{\"protocol\": \"unit.server\", \"packet\": \"end\"}");
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
                                string packet = "";
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
                                    packet += System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
                                    if (packet == "")
                                    {
                                        // データが空白なら
                                        break;
                                    }
                                    JObject json = JObject.Parse(packet);
                                    if ((string)json["protocol"] != "unit.client")
                                    {
                                        // プロトコルが不正なら
                                        continue;
                                    }
                                    if ((string)json["packet"] == "message")
                                    {
                                        // メッセージパケットなら
                                        sendData("{\"protocol\": \"unit.server\", \"packet\": \"message\", \"message\": \"" + client.Client.RemoteEndPoint + ": " + (string)json["message"] + "\"}");
                                        print(client.Client.RemoteEndPoint + ": " + (string) json["message"]);
                                        continue;
                                    }
                                    if ((string)json["packet"] == "connect")
                                    {
                                        // コネクトパケットなら
                                        sendData("{\"protocol\": \"unit.server\", \"packet\": \"message\", \"message\": \"" + client.Client.RemoteEndPoint + " connected.\"}");
                                        print(client.Client.RemoteEndPoint + " connected.");
                                        continue;
                                    }
                                    if ((string)json["packet"] == "disconnect")
                                    {
                                        // ディスコネクトパケットなら
                                        for (int i = clients.Count - 1; i >= 0; i--)
                                        {
                                            if (clients[i].Equals(client))
                                            {
                                                clients.RemoveAt(i);
                                            }
                                        }
                                        sendData("{\"protocol\": \"unit.server\", \"packet\": \"message\", \"message\": \"" + client.Client.RemoteEndPoint + " disconnected.\"}");
                                        print(client.Client.RemoteEndPoint + " disconnected.");
                                        continue;
                                    }

                                    System.Threading.Thread.Sleep(1);
                                }
                            }
                            catch (Exception e)
                            {
                                print("Failed to receive from client.: " + e.Message);
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(1);
                }
            });
        }

        public void sendData(string packet)
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
                        var data = System.Text.Encoding.UTF8.GetBytes(packet);
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
