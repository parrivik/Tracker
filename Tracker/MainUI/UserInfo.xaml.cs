using System;
using System.Collections.Generic;
using Tracker.RestService;
using Tracker.RestService.Data;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.MainUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Xamarin.Essentials;
using System.Globalization;





namespace Tracker.MainUI
{
    public partial class UserInfo : ContentPage
    {
        Tracker.RestService.RestService _restService;

        public UserInfo()
        {
            InitializeComponent();
            _restService = new Tracker.RestService.RestService();
        }


        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(idEntry.Text))
            {
                PersonData personData = await _restService.GetAllPersonDataAsync(GenerateRequestUri(Constants.BaseAddress));
                BindingContext = personData;
            }
        }



        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += "Person/ppPerson/";

            requestUri += $"{idEntry.Text}";

            requestUri += $"?apiKey={Constants.APIKey}";

            return requestUri;

        }


        async void JeSuisCLickedOnMap(object sender, EventArgs e)
        {
            LocationData locationParameter = null;

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best);
                Location location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    locationParameter = new LocationData
                    {
                        Guid = Guid.NewGuid(),
                        Latitude = location.Latitude,
                        Longitude = location.Longitude,
                        Timestamp = DateTime.Now.ToString(),
                        Velocity = (double)location.Speed,
                        UserId = App.logedInUser.Email
                    };

                }

                //UserData userData = await _restService.CreateUser(GenerateUser(Constants.createUser), userToSave);
                LocationData locationData = await _restService.CreateLocation(GenerateLocationUri(Constants.createPosition), locationParameter);


            }

            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }



        string GenerateLocationUri(string endpoint)
        {
            string requestUri = endpoint;

            requestUri += $"?apiKey={Constants.APIKey}";

            return requestUri;


        }



    }
}
