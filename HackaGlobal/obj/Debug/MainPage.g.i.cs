﻿#pragma checksum "D:\Programming\Windows Phone Projects\HackaGlobal\HackaGlobal\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6918AA87B6F3D7D7D0DD1442B0B32BA6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace HackaGlobal {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid BackgroundLayoutRoot;
        
        internal System.Windows.Controls.Grid ForegroundLayoutRoot;
        
        internal System.Windows.Controls.Grid HeaderPanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid TextListPanel;
        
        internal System.Windows.Controls.ListBox LocationList;
        
        internal System.Windows.Controls.Grid EventPanel;
        
        internal System.Windows.Controls.ListBox EventList;
        
        internal System.Windows.Controls.Grid LoadingPanel;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/HackaGlobal;component/MainPage.xaml", System.UriKind.Relative));
            this.BackgroundLayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("BackgroundLayoutRoot")));
            this.ForegroundLayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("ForegroundLayoutRoot")));
            this.HeaderPanel = ((System.Windows.Controls.Grid)(this.FindName("HeaderPanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.TextListPanel = ((System.Windows.Controls.Grid)(this.FindName("TextListPanel")));
            this.LocationList = ((System.Windows.Controls.ListBox)(this.FindName("LocationList")));
            this.EventPanel = ((System.Windows.Controls.Grid)(this.FindName("EventPanel")));
            this.EventList = ((System.Windows.Controls.ListBox)(this.FindName("EventList")));
            this.LoadingPanel = ((System.Windows.Controls.Grid)(this.FindName("LoadingPanel")));
        }
    }
}

