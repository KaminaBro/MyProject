using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace MyProject.Converters
{
    public class PathToBitmapConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string path && File.Exists(Environment.CurrentDirectory+"\\Images\\"+path))
            {
                // Загружаем изображение из файла
                return new Bitmap(Environment.CurrentDirectory +"\\Images\\" + path);
            }
            return new Bitmap(Environment.CurrentDirectory+"\\Images\\picture.png"); // Или изображение-заглушку
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
