using OctoLib;
using OctoLib.DataTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Octopus
{
    class NetHandler
    {
        static TcpClient tcpClient;
        static NetworkStream netStream;
        static List<byte> response = new List<byte>();
        static Process process;
        public static bool octoServWork = false;

        public static Reply StartServer()
        {
            try
            {
                if (!octoServWork)
                {
                    tcpClient = new TcpClient();
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = Program.configuration.octoServPath;
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.CreateNoWindow = true;
                    process = Process.Start(startInfo);
                    tcpClient.Connect(Program.configuration.address, Program.configuration.port);
                    netStream = tcpClient.GetStream();
                    octoServWork = true;
                }
                return new Reply(ReplyType.Success, "Сервер запущен. Подключение установлено");
            }
            catch (Exception ex)
            {
                return new Reply(ReplyType.Error, ex.Message);
            }
        }

        public static Reply StopServer()
        {
            try
            {
                if (octoServWork)
                {
                    process.Kill();
                    octoServWork = false;
                }
                return new Reply(ReplyType.Success, "Сервер остановлен");
            }
            catch(Exception ex)
            {
                return new Reply(ReplyType.Error, ex.Message);
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
