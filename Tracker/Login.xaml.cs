using System;
using System.Collections.Generic;
using Tracker.RestService.Data;
using Tracker;
using Xamarin.Forms;

namespace Tracker
{
    public partial class Login : ContentPage
    {
        Tracker.RestService.RestService _restService;

        public Login()
        {

            InitializeComponent();
            _restService = new Tracker.RestService.RestService();
        }

        /*
        async void OnLogin(object sender, EventArgs e)
        {

            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
        */

        async void OnLogin(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(email.Text) && !string.IsNullOrWhiteSpace(password.Text))
            {

                UserData userData = await _restService.CheckIfUserExists(GenerateRequestUri(Constants.get_userUri));

                if (userData != null && userData.Email.Equals(email.Text) && userData.Password.Equals(password.Text))
                {
                    BindingContext = userData;
                    App.logedInUser = userData;
                    Application.Current.MainPage = new MainUI.MainPage();
                }
                else
                {

                    await DisplayAlert("Alert", "Email or password are wrong !", "OK");
                }

            }

        }

        async void OnRegister(object sender, EventArgs e)
        {
            UserData userToSave = new UserData();
            userToSave.Email = registeremail.Text;
            userToSave.Password = registerpassword.Text;

            if (!string.IsNullOrWhiteSpace(registeremail.Text) && !string.IsNullOrWhiteSpace(registerpassword.Text))
            {
                UserData userData = await _restService.CreateUser(GenerateUser(Constants.createUser), userToSave);

                if (userData != null)
                {
                    BindingContext = userData;
                    App.logedInUser = userData;
                    Application.Current.MainPage = new MainUI.MainPage();
                }
                else 
                {
                    await DisplayAlert("Alert", "User already exists !", "OK");
                }

                //bool response = await DisplayAlert("Register", "Would you like to register yourself?", "Yes", "No");

            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"{email.Text}";

            requestUri += $"?apiKey={Constants.APIKey}";

            return requestUri;

        }


        string GenerateUser(string endpoint)
        {
            string requestUri = endpoint;

            requestUri += $"?apiKey={Constants.APIKey}";

            return requestUri;

        }




    }
}
