using DynamicDataTemplate.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DynamicDataTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<News> list = new List<News>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task getdata()
        {
            string jsonstr = await GetJsonFromFile();
            JsonObject jo = JsonObject.Parse(jsonstr);
            var status = jo["status"].ToString();
            if (status == "200")
            {
                foreach (var item in jo.GetNamedArray("data", new JsonArray()))
                {
                    if (item.ValueType == JsonValueType.Object)
                    {
                        string rs = item.Stringify();
                        byte[] array = Encoding.UTF8.GetBytes(rs);
                        MemoryStream stream = new MemoryStream(array);
                        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(News));
                        var s = (News)ser.ReadObject(stream);
                        list.Add(s);
                    }
                }
            }
            this.newslist.ItemsSource = list;
        }
        private async Task<string> GetJsonFromFile()
        {
            //设置文件的目录，在项目下的文件用ms-appx:///开始目录
            Uri datauri = new Uri("ms-appx:///SampleData.json");
            //文件读写可能会有异常
            try
            {
                //获取文件
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(datauri);
                //读取文件内容
                string jsonstring = await FileIO.ReadTextAsync(file);
                //返回文件内容
                return jsonstring;
            }
            catch (Exception e)
            {
                //打印异常信息
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await getdata();
        }
    }
}
