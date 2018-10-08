using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace SeldatMRMS.RobotView
{
    public class ConnectBridge
    {
        string IPADDRESS = "192.168.1.35";
        int PORT = 11000;
        Socket client = null;
        Thread pReceivingData;
        public Boolean isconnected = false;
        public Boolean flag_breakwaitconnect = false;
        public Boolean flag_alive = false;
        public delegate void GETDATA(String data);
        public GETDATA getdata;
        public delegate void ConnectionEvent(bool cnt);
        public ConnectionEvent connectionevent;
        public ConnectBridge() { }
        public void Connect()
        {
            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];
            pReceivingData = new Thread(RecievedData);
            pReceivingData.Start();
            flag_breakwaitconnect = false;
            flag_alive = true;

        }
        public void checkconnection()
        {

        }
        public void close()
        {
            flag_alive = false;
            flag_breakwaitconnect = false;
            if (client != null)
            {
                if (client.Connected)
                {
                    client.Close();
                }
                if (isconnected)
                {

                    isconnected = false;
                    pReceivingData = null;
                }
            }
        }
       public void sendpackage(String _cmd)
        {

            if (client != null)
            {
                if (client.Connected)
                {
                    try
                    {
                        byte[] cmd = Encoding.ASCII.GetBytes(_cmd+"#");
                        client.Send(cmd);
                    }
                    catch { }
                }
            }
        }
        public void RecievedData()
        {
            //  while (flag_alive)
            {
                try
                {
                    IPAddress _ipAddress = IPAddress.Parse(IPADDRESS);
                    IPEndPoint remoteEP = new IPEndPoint(_ipAddress, PORT);
                    NetworkStream ns = null;
                    StreamReader sr = null;
                    while (!flag_breakwaitconnect)
                    {
                        Console.WriteLine("waiting...");
                        try
                        {
                            if (client != null)
                                client = null;
                            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            client.Connect(remoteEP);
                            if (client.Connected)
                            {
                                Console.WriteLine("Accepted...");
                                flag_breakwaitconnect = false;
                                isconnected = true;
                                ns = new NetworkStream(client);
                                sr = new StreamReader(ns);
                              //  connectionevent(true);
                                break;
                            }
                        }
                        catch { }
                    }
                    while (client.Connected)
                    {
                        try
                        {
                            String data = sr.ReadLine();
                            getdata(data);
                        }
                        catch
                        {
                           if (client != null)
                            if (!client.Connected)
                            {
                                    client.Close();
                                  //  connectionevent(false);
                            }
                            break;
                        }
                    }

                }
                catch
                {
                    if (client != null)
                        if (!client.Connected)
                        {
                            client.Close();
                            //connectionevent(false);
                        }
                }
            }
        }
    }

}
