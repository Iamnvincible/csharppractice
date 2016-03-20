using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ThreadProgressring
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        delegate void myde(int a, int b);
        delegate void myde2();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.txt.Text = DateTime.Now.ToString();
            string x = "";
            HttpClient h = new HttpClient();
            try
            {
                x = await h.GetStringAsync(new Uri("http://202.202.43.125/"));
            }
            catch (Exception xx)
            {
                Debug.WriteLine(xx.Message);
            }
            Debug.WriteLine(x);
            Debug.WriteLine("-=--------------------------------------------------------");

            x = await getstring(new Uri("http://202.202.43.125/"));
            Task<string> rrrrr = getstring(new Uri("http://202.202.43.125/"));
            var c = await rrrrr;
            Debug.WriteLine(x);
        }

        private async void longtime(object sender, RoutedEventArgs e)
        {
            this.pro.IsActive = true;
            //fun(1, 1);
            //this.pro.IsActive = false;
            //stk.Children.Clear();
            await Task.Factory.StartNew(() =>
             {
                 fun(1, 2);
             });
            for (int i = 0; i < 4200; i++)
            {
                TextBlock tb = new TextBlock();
                tb.Text = "added";
                //stk.Children.Add(tb);
            }
            //myde f = new myde(fun);

            // f.BeginInvoke(0, 100000, new AsyncCallback(mycall), "");
            //await Task.Delay(2000);
        }

        async void fun(int a, int b)
        {
            for (int i = 0; i < 1000; i++)
            {
                string x = i.ToString();
                Debug.WriteLine(i);
            }
            await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
           {
               pro.IsActive = false;
           });
        }
        async Task<string> getstring(Uri uri)
        {

            HttpClient hc = new HttpClient();
            string result = "";
            try
            {
                result = await hc.GetStringAsync(uri);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                Debug.WriteLine(result);
            }
            return result;

        }
    }
}
