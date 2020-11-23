using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;
using Autofac.Core;

namespace CurrencyInfoUWP.ViewModels
{
    public sealed class ViewModelLocator
    {        
        public MainPageViewModel MainPageViewModel
        {
            get {
                try
                {
                    return Container.GetContainer().Resolve<MainPageViewModel>();
                }
                catch(DependencyResolutionException e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }
        }

        public ViewModelLocator() { }
    }
}
