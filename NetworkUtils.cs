using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace Utilities
{
    public class NetworkUtils
    {

        public  static string GetIPs()
        {
            var ipList = new System.Text.StringBuilder();

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)//just need IPv4
                    ipList.Append($"{addr[i].ToString()}, ");
            }

            return ipList.ToString().Trim(',');
        }

        public static string GetRequestInfo(IHttpContextAccessor httpContextAccessor) {

            return $"{httpContextAccessor.HttpContext.Request.Host}" +
                $" {httpContextAccessor.HttpContext.User.Identity.Name}" +
                $" authenticated: {httpContextAccessor.HttpContext.User.Identity.IsAuthenticated}" +
                $" {httpContextAccessor.HttpContext.User.Identity.AuthenticationType}";
        }

    }
}
