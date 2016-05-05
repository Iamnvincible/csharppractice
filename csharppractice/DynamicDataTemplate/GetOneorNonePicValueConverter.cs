using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace DynamicDataTemplate
{
    public class GetOneorNonePicValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string src = value as string;
            if (src == "")
            {
                return "";
            }
            else if (src.Split(',').Length > 1)
            {
                var s = src.Split(',')[0];
                return s;
            }
            else
            {
                return src;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
