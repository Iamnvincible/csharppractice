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
    public class ImgDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OnePhotoTemplate { get; set; }
        public DataTemplate TwoPhotoTemplate { get; set; }
        public DataTemplate MorePhotoTemplate { get; set; }
        protected override DataTemplate SelectTemplateCore(System.Object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is News)
            {
                News newsitem = item as News;

                if (newsitem.img.Length == 1)
                    return OnePhotoTemplate;
                else if (newsitem.img.Length == 2)
                    return TwoPhotoTemplate;
                else return MorePhotoTemplate;
            }
            return null;
        }
    }
}
