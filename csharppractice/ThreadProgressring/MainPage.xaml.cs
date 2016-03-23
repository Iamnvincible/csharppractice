using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
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
            //this.txt.Text = DateTime.Now.ToString();
            //string x = "";
            //HttpClient h = new HttpClient();
            //try
            //{
            //    var response = h.GetBufferAsync(new Uri("http://202.202.43.125/"));

            //    x = await h.GetStringAsync(new Uri("http://202.202.43.125/"));
            //}
            //catch (Exception xx)
            //{
            //    Debug.WriteLine(xx.Message);
            //}
            //Debug.WriteLine(x);
            //Debug.WriteLine("-=--------------------------------------------------------");
            ////异步执行并得到结果
            //x = await getstring(new Uri("http://202.202.43.125/"));
            ////异步赋值在执行
            //Task<string> rrrrr = getstring(new Uri("http://202.202.43.125/"));
            //var c = await rrrrr;
            //Debug.WriteLine(x);
            HttpClient httpclient = new HttpClient();
            var uri = new Uri("http://apis.baidu.com/songshuxiansheng/real_time/search_news?keyword=明星");
            httpclient.DefaultRequestHeaders.Add("apikey", "9a84555d8b243d4afa83cac9855b60e7");
            var response = await httpclient.GetAsync(uri);
            var r2 = await httpclient.GetStringAsync(uri);
            var r3 = await httpclient.GetBufferAsync(uri);
            var r33 = r3.ToArray();
            string result = Encoding.UTF8.GetString(r33);
            string humanlike = Decode(result);
            Debug.Write(humanlike);
            //char[] aaaa =
            //{
            //   (Char)0x4ed6,(Char)0x662f,(Char)0x5a31,(Char)0x4e50,(Char)0x5708,(Char)0x91cc,(Char)0x6700,(Char)0x5bd2,(Char)0x9178,(Char)0x7684,(Char)0x660e,(Char)0x661f,(Char)0xff0c,(Char)0x5374,(Char)0x503c,(Char)0x5f97,(Char)0x6bcf,(Char)0x4e00,(Char)0x4e2a,(Char)0x4eba,(Char)0x5c0a,(Char)0x91cd,(Char)0xff01
            //};
            //foreach (var VARIABLE in aaaa)
            //{
            //    Debug.Write(VARIABLE);
            //}
        }

        public static string Decode(string s)
        {
            Regex reUnicode = new Regex(@"\\u([0-9a-fA-F]{4})", RegexOptions.Compiled);
            return reUnicode.Replace(s, m =>
            {
                short c;
                if (short.TryParse(m.Groups[1].Value, System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture, out c))
                {
                    return "" + (char)c;
                }
                return m.Value;
            });
        }
        //  textblock.Text = await response.Content.ReadAsStringAsync();

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
