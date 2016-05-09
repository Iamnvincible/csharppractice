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
            string s = (string)value;
            int index = 0;
            while ((index = s.IndexOf("#")) >= 0)
            {
                if (s.Substring(index + 1).IndexOf("#") >= 0)
                {
                    if (index != 0)
                    {
                        Run r = new Run();
                        r.Text = s.Substring(0, index);
                        span.Inlines.Add(r);
                        s = s.Substring(index);
                        index = 0;
                    }
                    int index2 = s.Substring(index + 1).IndexOf("#");
                    if (index2 > 0)
                    {
                        string highlight = s.Substring(index, index2 + index + 2);
                        Run high = new Run();
                        high.Text = highlight;
                        high.Foreground = new SolidColorBrush(Color.FromArgb(255, 80, 125, 175));
                        span.Inlines.Add(high);
                        s = s.Substring(index2 + index + 2);
                        index = 0;
                    }

                }
                else
                {
                    break;
                }

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
            Run left = new Run();
            left.Text = s;
            span.Inlines.Add(left);
            return span;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
