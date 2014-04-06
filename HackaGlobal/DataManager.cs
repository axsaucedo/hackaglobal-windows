using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace HackaGlobal
{
    public enum CurrentlyViewing { Countries, Cities, Events }

    static class DataManager
    {
        private static ListBox targetListBox;
        private static WebClient webClient;

        public static MainPage MainPage;

        public static string RootUrl { get { return Resources.AppResources.RootUrl; } }
        public static string DataUrl { get { return RootUrl + "data/"; } }
        public static string LocationsUrl { get { return RootUrl + "country/"; } }

        public static List<string> CountryList { get; private set; }
        public static List<string> CityList { get; private set; }
        public static List<Event> EventList { get; private set; }

        public static int SelectedCountryIndex { get; set; }
        public static int SelectedCityIndex { get; set; }
        public static int SelectedEventIndex { get; set; }

        public static CurrentlyViewing CurrentlyViewing { get; private set; }

        public static List<EventButtonData> ParseEventListToDataList(List<Event> events)
        {
            var buttonlist = new List<EventButtonData>();

            events.ForEach(e =>
            {
                var data = new EventButtonData()
                {
                    Name = e.name,
                    Location = e.address + ", " + e.city + ", " + e.country,
                    Start = "Starts at " + e.start.Replace("T", " from "),
                    End = "Ends on " + e.start.Replace("T", " at "),
                    Description = (e.description.Length > 160)? e.description.Substring(0, 160) + "..." : e.description
                };

                buttonlist.Add(data);
            });

            return buttonlist;
        }

        public static List<LocationButtonData> ParseLocationListToDataList(List<string> locations)
        {
            var buttonlist = new List<LocationButtonData>();

            locations.ForEach(location =>
            {
                var data = new LocationButtonData()
                {
                    Name = location
                };

                buttonlist.Add(data);
            });

            return buttonlist;
        }

        public static void UpdateList(ListBox targetList, int selectionIndex, int viewId)
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
                    if (selectionIndex != -1) SelectedCountryIndex = selectionIndex;
                    url = LocationsUrl + CountryList[SelectedCountryIndex];
                    break;

                case 2:
                    CurrentlyViewing = CurrentlyViewing.Events;
                    if (selectionIndex != -1) SelectedCityIndex = selectionIndex;
                    url = DataUrl + CountryList[SelectedCountryIndex] + '/' + CityList[SelectedCityIndex];
                    break;
            }

            webClient = new WebClient();
            webClient.DownloadStringCompleted += webClient_DownloadStringCompleted;
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
                            CountryList = JsonConvert.DeserializeObject<List<string>>(e.Result);
                            targetListBox.ItemsSource = ParseLocationListToDataList(CountryList);
                            break;

                        case CurrentlyViewing.Cities:
                            CityList = JsonConvert.DeserializeObject<List<string>>(e.Result);
                            targetListBox.ItemsSource = ParseLocationListToDataList(CityList);
                            break;

                        case CurrentlyViewing.Events:
                            EventList = JsonConvert.DeserializeObject<List<Event>>(e.Result);
                            targetListBox.ItemsSource = ParseEventListToDataList(EventList);
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
