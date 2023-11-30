﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace LadderGameApp
{
    internal class Navigator
    {
        internal static void MovePage(NavigationService navigation, Page page)
        {
            navigation.Navigate(page);
        }
    }
}