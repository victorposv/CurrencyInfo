using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public interface IConnectionInfo
    {
        string Url { get; set; }

        string AccessToken { get; set; }
    }
}
