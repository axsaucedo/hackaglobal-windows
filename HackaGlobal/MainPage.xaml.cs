using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace HackaGlobal
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool isInitializing;
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
            switch (View)
            {
                case 0:
                    ListPanel.Visibility = Visibility.Visible;
                    EventPanel.Visibility = Visibility.Collapsed;
                    DataManager.UpdateList(ListBox, View);
                    break;

                case 1:
                    ListPanel.Visibility = Visibility.Visible;
                    EventPanel.Visibility = Visibility.Collapsed;
                    DataManager.UpdateList(ListBox, View);
                    break;

                case 2:
                    ListPanel.Visibility = Visibility.Visible;
                    EventPanel.Visibility = Visibility.Collapsed;
                    DataManager.UpdateList(ListBox, View);
                    break;
                
                case 3:
                    ListPanel.Visibility = Visibility.Collapsed;
                    EventPanel.Visibility = Visibility.Visible;

                    // Loads the event.

                    break;
            }
        }

        public void FinishInitialization()
        {
            isInitializing = false;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isInitializing)
            {
                isInitializing = true;
                View++;
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
    }
}