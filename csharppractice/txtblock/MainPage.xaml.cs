using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace txtblock
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public string str { get; set; } = "#微软创新杯#ImagineCup #2016#中国#区总决赛";
        public MainPage()
        {
            this.InitializeComponent();
            List<Item> items = new List<Item>();
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis="0"});
            items.Add(new Item {S = "222222222222222",vis= "0" });
        
            this.listview.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            b.Visibility = Visibility.Collapsed;
        }

        private void listview_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var a= VisualTreeHelper./*GetChild*/(sender,1);

            //for
            //listview.ContainerFromItem()
            //var x=e.OriginalSource;
            //var z = FindVisualChild<ListViewItem>(e.OriginalSource as DependencyObject);
            //DependencyObject x = VisualTreeHelper.GetParent(listview as DependencyObject);
            //StackPanel g = x as StackPanel;
            //var z = g.Children[0];
            //var p = z as ProgressRing;
            //p.IsActive = false;
            //((Item)e.ClickedItem).vis = "1";
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //DependencyObject x = VisualTreeHelper.GetChild(sender as DependencyObject,1);
            //Button c = x as Button;
            //c.Visibility = Visibility.Visible;
        }
        private  void Selectionchanged(object sender, SelectionChangedEventArgs args)
        {
            foreach (var item in args.AddedItems)
            {
                ListViewItem itema = (sender as ListView).ContainerFromItem(item) as ListViewItem;
                Button x=FindVisualChild<Button>(itema);
                x.Visibility = Visibility.Visible;
            }
        }

        private ChildType FindVisualChild<ChildType>(DependencyObject obj) where ChildType : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is ChildType)
                {
                    return child as ChildType;
                }
                else
                {
                    ChildType childOfChildren = FindVisualChild<ChildType>(child);
                    if (childOfChildren != null)
                    {
                        return childOfChildren;
                    }
                }
            }
            return null;

        }

        private T FindTargetChildType<T>(DependencyObject obj) where T : DependencyObject
        {
            while (obj != null)
            {
                int childerncount = VisualTreeHelper.GetChildrenCount(obj);
                for (int i = 0; i < childerncount; i++)
                {
                    if (VisualTreeHelper.GetChild(obj, i) is T)
                    {
                        return VisualTreeHelper.GetChild(obj, i) as T;
                    }
                    else
                    {
                        return FindVisualChild<T>(VisualTreeHelper.GetChild(obj, i));
                    }
                }
                return null;
            }
            return null;
        }


    }

    public class Item
    {
        public string S { get; set; }
        public string vis { get; set; }
    }
}
