using System.ComponentModel;
using System.Runtime.CompilerServices;

using Shared.Models;

namespace CurrencyInfoUWP.Models
{
    public class SelectedOptions : INotifyPropertyChanged, ISelectedOptions
    {
        public string SelectedBank { get; set; }
        public string SelectedCurrency { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
