using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Swd.PlayCollector.Gui.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTA5MTk1NkAzMjMwMmUzNDJlMzBHME12Sy85RTJuSTFqdEJhYUNXNXBJWGZaeE43ZmpBYUM1ZUowVkllOUZNPQ=="); 
        }
    }
}