using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using OctoLib;

namespace OctoServ
{
    class Listener
    {
        TcpListener _listener;
        TcpClient _tcpClient;
        Thread _listenerThread;
        NetworkStream _stream;
        Configuration _configuration;

        delegate void del_ConnectManager(string operation, Object data);

        bool connected = false;
        bool started = false;

        public Listener()
        {
            _configuration = Program.configuration;
        }

        public void StartListener()
        {
            _listenerThread = new Thread(new ParameterizedThreadStart(ListenerWork));
            _listenerThread.Start();
        }

        void ListenerWork(object sender)
        {
            started = true;
            _listener = new TcpListener(IPAddress.Parse(_configuration.address), _configuration.port);
            _listener.Start();
            _tcpClient = _listener.AcceptTcpClient();
            _stream = new NetworkStream(_tcpClient.Client);
            connected = true;
            while (connected)
            {
                if(_tcpClient.Available > 0)
                {
                    Byte[] bytesRecieve = new Byte[_tcpClient.Available];
                    _stream = _tcpClient.GetStream();
                    _stream.Read(bytesRecieve, 0, _tcpClient.Available);
                    string dataRecieve = Encoding.UTF8.GetString(bytesRecieve);
                    var byteRequest = Encoding.UTF8.GetBytes(ReplyTranslator.ReplyToString(NetCommandHandler.HandleCommand(dataRecieve)));
                    _stream.Write(byteRequest);
                }
                Thread.Sleep(5);
            }
            _stream.Close();
            _tcpClient.Close();
            _listener.Stop();
        }
    }
}
