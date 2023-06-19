using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace caro
{
    public class quantrimang
    {
        #region Client
        Socket client;
        public bool KetNoiVoiServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), Port);
            client = new Socket(AddressFamily.InterNetwork ,SocketType.Stream,ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
                return true;
            }
            catch { return false; }
           
        }
        #endregion


        #region Server
        Socket server;
        public void TaoServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(IP), Port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);
            Thread accpectClient = new Thread( () =>
                {
                    client = server.Accept();
                });
            accpectClient.IsBackground= true;
            accpectClient.Start();
        }
        #endregion

        #region CaHai
        public string IP ="127.0.0.1";
        public int Port = 9999;
        public const int BUFFER = 1024;
        public bool cophaiServerkhong = true;
        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
             return GuiData(client, sendData);
                
        }
        public object Receieve()
        {
            byte[] nhandata = new byte[BUFFER];
            bool isOK = NhanData(client, nhandata);
            return DeserializeData(nhandata);
        }
        private bool GuiData(Socket target , byte[] data)
        {
            return target.Send(data)==1 ? true : false;
        }
        private bool NhanData(Socket target ,  byte[] data )
        {
            return target.Receive(data)==1? true : false ;
        }
        public string GetLocalIPv4(NetworkInterfaceType _type) 
        {
            string output = "";
            foreach(NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus== OperationalStatus.Up)
                {
                    foreach(UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if(ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }    
                }
            }    
            return output;
        }
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms =new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        public object DeserializeData(byte[] data)
        {
            MemoryStream ms =   new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        #endregion  
    }
}
