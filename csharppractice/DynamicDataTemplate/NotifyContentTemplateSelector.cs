using DynamicDataTemplate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DynamicDataTemplate
{
    public class NotifyContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate RemarkTemplate { get; set; }
        public DataTemplate PraiseTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(System.Object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            MyNotification noti = item as MyNotification;
            if (element != null && noti != null)
            {
                if (noti.content == "")
                {
                    return PraiseTemplate;
                }
                else
                {
                    return RemarkTemplate;
                }
            }
            return RemarkTemplate;
        }
    }
}
