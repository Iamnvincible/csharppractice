using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace txtblock
{
    public class stringconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }

            var span = new Span();
            span.Inlines.Add(new Run("Question1: "));
            span.Inlines.Add(new Run("Answer1") { FontWeight = FontWeights.Bold });
            span.Inlines.Add(new Run(", "));

            span.Inlines.Add(new Run("Question2: "));
            span.Inlines.Add(new Run("Answer2") { FontWeight = FontWeights.Bold });
            span.Inlines.Add(new Run(", "));

            span.Inlines.Add(new Run("Question3: "));
            span.Inlines.Add(new Run("Answer3") { FontWeight = FontWeights.Bold });

            return span;
            //string s = (string)value;
            //StackPanel sp = new StackPanel();
            //sp.Orientation = Orientation.Horizontal;
            //int index = 0;
            //while ((index = s.IndexOf("#")) >= 0)
            //{
            //    if (s.Substring(index + 1).IndexOf("#") >= 0)
            //    {
            //        if (index != 0)
            //        {
            //            TextBlock tb0 = new TextBlock();
            //            tb0.Text = s.Substring(0, index);
            //            sp.Children.Add(tb0);
            //            s = s.Substring(index);
            //            index = 0;
            //        }
            //        int index2 = s.Substring(index + 1).IndexOf("#");
            //        string highlight = s.Substring(index, index2 + index + 2);
            //        TextBlock tb1 = new TextBlock();
            //        tb1.Text = highlight;
            //        tb1.Foreground = new SolidColorBrush(Color.FromArgb(255, 80, 125, 175));
            //        sp.Children.Add(tb1);
            //        s = s.Substring(index2 + index + 2);
            //        index = 0;
            //    }
            //}
            //TextBlock tb = new TextBlock();
            //tb.Text = s;
            //sp.Children.Add(tb);
            //tb = new TextBlock();
            //tb.Foreground = new SolidColorBrush(Color.FromArgb(255, 24, 56, 99));
            //sp.Children.Add(tb);
            //return sp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
