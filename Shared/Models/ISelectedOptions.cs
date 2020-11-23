using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public interface ISelectedOptions
    {
        string SelectedBank { get; set; }
        string SelectedCurrency { get; set; }
    }
}
