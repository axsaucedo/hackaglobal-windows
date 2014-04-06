using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace HackaGlobal
{
    public partial class MainPage : PhoneApplicationPage
    {
        private int selectionIndex;
        private int view;

        public int View
        {
            get { return view; }
            set { view = value; Initialize(); }
        }

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataManager.MainPage = this;
            View = 0;
        }

        public void Initialize()
        {
            TextListPanel.Visibility = Visibility.Collapsed;
            EventPanel.Visibility = Visibility.Collapsed;
            LoadingPanel.Visibility = Visibility.Visible;

            switch (View)
            {
                case 0:
                    DataManager.UpdateList(LocationList, selectionIndex, View);
                    break;

                case 1:
                    DataManager.UpdateList(LocationList, selectionIndex, View);
                    break;

                case 2:
                    DataManager.UpdateList(EventList, selectionIndex, View);
                    break;
            }

            selectionIndex = -1;
        }

        public void FinishInitialization()
        {
            LoadingPanel.Visibility = Visibility.Collapsed;
            
            switch (View)
            {
                case 0:
                    TextListPanel.Visibility = Visibility.Visible;
                    EventPanel.Visibility = Visibility.Collapsed;
                    break;

                case 1:
                    TextListPanel.Visibility = Visibility.Visible;
                    EventPanel.Visibility = Visibility.Collapsed;
                    break;

                case 2:
                    TextListPanel.Visibility = Visibility.Collapsed;
                    EventPanel.Visibility = Visibility.Visible;
                    break;
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (View > 0)
            {
                View--;
                e.Cancel = true;
            }
        }

        #region Events
        private void LocationList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectionIndex == -1 && LocationList.SelectedIndex != -1)
            {
                selectionIndex = LocationList.SelectedIndex;
                if (View < 2) View++;
                selectionIndex = -1;
            }
        }

        private void EventList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EventList.SelectedIndex != -1)
            {
                var website = DataManager.EventList[EventList.SelectedIndex].website;

                if (website != "")
                {
                    WebBrowserTask webBrowserTask = new WebBrowserTask();
                    webBrowserTask.Uri = new Uri(website, UriKind.Absolute);

                    try { webBrowserTask.Show(); }
                    catch { MessageBox.Show("Could not launch website."); }
                }
                else
                {
                    MessageBox.Show("No website has been specified for this event.");
                }

                EventList.SelectedIndex = -1;
            }
        }

        private void ApplicationBarRefresh_Click(object sender, EventArgs e)
        {
            Initialize();
        }
        #endregion
    }
}