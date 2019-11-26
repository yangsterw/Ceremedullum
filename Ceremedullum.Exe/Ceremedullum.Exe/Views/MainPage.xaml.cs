﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Ceremedullum.Exe.Views.MainPageContentFrame;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Ceremedullum.Exe.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can also add items in code behind
            //NavView.MenuItems.Add(new NavigationViewItemSeparator());
            //NavView.MenuItems.Add(new NavigationViewItem()
            //    {Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content"});

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "home")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                //ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate((NavigationViewItem) item);
            }
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            var rootFrame = Window.Current.Content as Frame;

            switch (item.Tag)
            {
                case "home":
                    rootFrame.Navigate(typeof(MainPage));
                    break;

                case "searchPatient":
                    ContentFrame.Navigate(typeof(SearchPatient));
                    break;

                case "searchDisease":
                    ContentFrame.Navigate(typeof(SearchDiseases));
                    break;

                case "history":
                    //ContentFrame.Navigate(typeof(SearchHistory));
                    break;

                case "logout":
                   rootFrame.Navigate(typeof(LoginPage));
                    break;
                case "settings":
                    //ContentFrame.Navigate(typeof(settings));
                    break;
            }
        }
    }
}
