﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tracker.MainUI;
using Tracker.RestService.Data;

namespace Tracker
{
    public partial class App : Application
    {

        public static UserData logedInUser;

        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
