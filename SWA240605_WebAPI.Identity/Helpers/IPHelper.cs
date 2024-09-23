using System.Net.Sockets;
using System.Net;

namespace SWA240605_WebAPI.Identity.Helpers
{
    public class IPHelper
    {
        public static string GetIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }
    }
}
