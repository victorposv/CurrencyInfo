using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    class SignalRConnectionInfo : IConnectionInfo
    {
        public string Url { get; set; }
        public string AccessToken { get; set; }
    }
}
