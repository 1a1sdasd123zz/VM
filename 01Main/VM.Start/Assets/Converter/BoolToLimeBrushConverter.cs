﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace VM.Start.Assets.Converter
{
    public class BoolToLimeBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && bool.TryParse(value.ToString(), out bool result) && result)
            {
                return Brushes.Lime;
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
