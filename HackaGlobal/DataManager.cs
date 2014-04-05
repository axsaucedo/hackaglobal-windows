using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace HackaGlobal
{
    public enum CurrentlyViewing { Countries, Cities, Events, EventDetails }

    static class DataManager
    {
        private static ListBox targetListBox;
        private static WebClient webClient;

        public static MainPage MainPage;

        public static string RootUrl { get { return "http://22ba183c.ngrok.com/api/"; } }
        public static string DataUrl { get { return RootUrl + "data/"; } }
        public static string LocationsUrl { get { return RootUrl + "country/"; } }

        public static LoadedCountries CountryList { get; private set; }
        public static LoadedCities CityList { get; private set; }
        public static LoadedEvents EventList { get; private set; }
        public static Event SelectedEvent { get; private set; }

        public static int SelectedCountryIndex { get; set; }
        public static int SelectedCityIndex { get; set; }
        public static int SelectedEventIndex { get; set; }

        public static CurrentlyViewing CurrentlyViewing { get; private set; }

        static DataManager()
        {
            webClient = new WebClient();
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
        }

        public static void UpdateList(ListBox targetList, int viewId)
        {
            targetListBox = targetList;

            var url = "";

            switch (viewId)
            {
                case 0:
                    CurrentlyViewing = CurrentlyViewing.Countries;
                    url = LocationsUrl;
                    break;

                case 1:
                    CurrentlyViewing = CurrentlyViewing.Cities;
                    if (targetListBox.SelectedIndex != -1) SelectedCountryIndex = targetListBox.SelectedIndex;
                    url = LocationsUrl + CountryList.countries[SelectedCountryIndex];
                    break;

                case 2:
                    CurrentlyViewing = CurrentlyViewing.Events;
                    if (targetListBox.SelectedIndex != -1) SelectedCityIndex = targetListBox.SelectedIndex;
                    url = DataUrl + CountryList.countries[SelectedCountryIndex] + '/' + CityList.cities[SelectedCityIndex];
                    break;

                case 3:
                    CurrentlyViewing = CurrentlyViewing.EventDetails;
                    if (targetListBox.SelectedIndex != -1) SelectedEventIndex = targetListBox.SelectedIndex;
                    url = DataUrl + CountryList.countries[SelectedCountryIndex] + '/' + CityList.cities[SelectedCityIndex] + '/' + EventList.events[SelectedEventIndex];
                    break;
            }

            webClient.DownloadStringAsync(new Uri(url));
        }

        static void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    switch (CurrentlyViewing)
                    {
                        case CurrentlyViewing.Countries:
                            CountryList = JsonConvert.DeserializeObject<LoadedCountries>(e.Result);
                            targetListBox.ItemsSource = CountryList.ToStringList();
                            break;

                        case CurrentlyViewing.Cities:
                            CityList = JsonConvert.DeserializeObject<LoadedCities>(e.Result);
                            targetListBox.ItemsSource = CityList.ToStringList();
                            break;

                        case CurrentlyViewing.Events:
                            EventList = JsonConvert.DeserializeObject<LoadedEvents>(e.Result);
                            targetListBox.ItemsSource = EventList.ToStringList();
                            break;

                        case CurrentlyViewing.EventDetails:
                            break;
                    }
                }
            }
            catch (Exception x)
            {
                ExceptionManager.Log(x);
            }
            finally
            {
                MainPage.FinishInitialization();
            }
        }
    }
}
