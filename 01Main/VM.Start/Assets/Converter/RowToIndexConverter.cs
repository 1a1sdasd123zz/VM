using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace VM.Start.Assets.Converter
{
    public class RowToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DataGridRow row = value as DataGridRow;
            if (row != null)
                return row.GetIndex();
            else
                return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
