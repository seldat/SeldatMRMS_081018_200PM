using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SeldatMRMS
{
    class TcpServer
    {
        private TcpListener _server;
        private Boolean _isRunning;
        Thread tt;
        public TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();
            _isRunning = true;
           tt=new Thread( LoopClients);
            tt.Start();
        }

        public void LoopClients()
        {
            while (_isRunning)
            {
                // wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;
            // sets two streams
            StreamWriter writer = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested
            Boolean bClientConnected = true;
            String sData = null;
           // reads from stream
            sData = sReader.ReadLine();
            Uri myUri = new Uri("http://www.example.com?param1=good&param2=bad");
            string param1 = HttpUtility.ParseQueryString(myUri.Query).Get("param1");
            Console.WriteLine(param1);
            string content = "{" + "  \"version\": \"1.0\" " + "\"data\": {" + " \"sampleArray\": [" + " \"string value\"," + " 5,";
            writer.Write("HTTP/1.0 200 OK");
            writer.Write(Environment.NewLine);
            writer.Write("Content-Type: text/plain; charset=UTF-8");
            writer.Write(Environment.NewLine);
            writer.Write("Content-Length: " + content.Length);
            writer.Write(Environment.NewLine);
            writer.Write(Environment.NewLine);
            writer.Write(content);
            writer.Flush();
            client.Close();

        }
    }
}
