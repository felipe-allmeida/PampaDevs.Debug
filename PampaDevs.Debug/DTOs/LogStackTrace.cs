using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PampaDevs.Debug.DTOs
{
    public struct LogStackTrace
    {
        public string Address;
        public string MethodName;
        public List<string> Parameters;
    }
}
