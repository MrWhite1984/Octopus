using OctoLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus
{
    class NetHandler
    {
        static TcpClient tcpClient;
        static NetworkStream netStream;
        static List<byte> response = new List<byte>();
        static Process process;
        public static bool octoServWork = false;

        public static void StartServer()
        {
            if (!octoServWork)
            {
                tcpClient = new TcpClient();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Program.configuration.octoServPath;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;
                process = Process.Start(startInfo);
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 1111);
                netStream = tcpClient.GetStream();
                octoServWork = true;
            }
        }

        public static void StopServer()
        {
            if (octoServWork)
            {

                process.Kill();
                octoServWork= false;
            }
        }
        public static Reply Send(string request)
        {
            var byteRequest = Encoding.UTF8.GetBytes(request);
            netStream.Write(byteRequest, 0, byteRequest.Length);
            Thread.Sleep(50);
            netStream = tcpClient.GetStream();
            Byte[] byteResponse = new Byte[tcpClient.Available];
            netStream.Read(byteResponse, 0, tcpClient.Available);
            return ReplyTranslator.StringToReply(Encoding.UTF8.GetString(byteResponse));
        }
    }
}
