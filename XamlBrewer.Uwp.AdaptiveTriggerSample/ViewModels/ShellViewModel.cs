﻿using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlBrewer.Uwp.AdaptiveTriggerSample.Views;

namespace XamlBrewer.Uwp.AdaptiveTriggerSample.ViewModels
{
    class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menu
            Menu.Add(new MenuItem() { Glyph = "", Text = "Rainbows", NavigationDestination = typeof(MainPage) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Unicorns", NavigationDestination = typeof(MainPage) });
            Menu.Add(new MenuItem() { Glyph = "", Text = "Butterflies", NavigationDestination = typeof(MainPage) });
        }
    }
}
