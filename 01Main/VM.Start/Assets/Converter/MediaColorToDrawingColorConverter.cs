using System;
using System.Globalization;
using System.Windows.Data;

namespace VM.Start.Assets.Converter
{
    public class MediaColorToDrawingColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Drawing.Color drawColor = (System.Drawing.Color)value;
            System.Windows.Media.Color mediaColor = System.Windows.Media.Color.FromArgb(drawColor.A, drawColor.R, drawColor.G, drawColor.B);
            return mediaColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            System.Windows.Media.Color mediaColor = (System.Windows.Media.Color)value;
            System.Drawing.Color drawingColor = System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
            return drawingColor;
        }
    }

}
