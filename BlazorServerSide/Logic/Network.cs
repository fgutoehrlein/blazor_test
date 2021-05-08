using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace BlazorServerSide.Logic
{
    public class Network
    {
        public static IPAddress GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Message: " + e.Message);
            }
            return null;
        }
    }
}
