﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace VM.Start.Assets.Converter
{
    public class EnumToVisibilityConverter_2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // value:ViewModel.Property,enum,Apple
            // parameter:ConverterParameter,enum,Banana 
            if (value.Equals(parameter))
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // value:bool,RadioButton.IsChecked,value
            // parameter:ConverterParameter,enum,Banana
            if (value is bool b && b)
                return parameter;
            return Binding.DoNothing;
        }
    }

}
