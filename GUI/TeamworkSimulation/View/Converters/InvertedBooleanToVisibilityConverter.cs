using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace TeamworkSimulation.View
{
    public class InvertedBooleanToVisibilityConverter : IValueConverter
    {

        private static BooleanToVisibilityConverter bool2VisibConv = new BooleanToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility result = (Visibility)bool2VisibConv.Convert(value, targetType, parameter, culture);

            if (result == Visibility.Visible)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = (bool)bool2VisibConv.ConvertBack(value, targetType, parameter, culture);

            return !result;
        }
    }
}
