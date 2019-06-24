using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tracker.MainUI;

using Xamarin.Forms;

namespace Tracker.MainUI
{
    public partial class UserSettings : ContentPage
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        public void OnLogout(object sender, EventArgs e)
        {
            Maps.trackingThread.Abort();
            App.logedInUser = null;
            Application.Current.MainPage = new Login();

        }
    }
}
