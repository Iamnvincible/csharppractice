using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Encodingtest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public const string test = "Aa0严";
        public const string filename = "test.txt";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] b = Encoding.UTF8.GetBytes(test);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(b[i]);
            }
            display.Text = sb.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            byte[] b = Encoding.Unicode.GetBytes(test);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(b[i]);
            }
            display.Text = sb.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            writeTextToLocalStorageFile(filename, test);
        }
        private async void writeTextToLocalStorageFile(string filename, string text)
        {
            StorageFolder fold = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file =
                await fold.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, text);
            display.Text = $"{test}已经写入到文件{filename}";
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string read = await readTextFromLocalStorage(filename);
            display.Text = read;
        }
        private async Task<string> readTextFromLocalStorage(string filename)
        {
            var fold = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await fold.GetFileAsync(filename);
            string result = await FileIO.ReadTextAsync(file);
            return result;
        }

        private async void Button_Click_4(object sender, RoutedEventArgs e)
        {
            IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            IStorageFile storageFile = await applicationFolder.GetFileAsync(filename);
            await storageFile.DeleteAsync();
            display.Text = "删除成功";
        }

        private async void Button_Click_5(object sender, RoutedEventArgs e)
        {
            IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await applicationFolder.CreateFileAsync("text.dat", CreationCollisionOption.ReplaceExisting);
            if (file != null)
            {
                try
                {
                    string userContent = "测试的文本消息";
                    IBuffer buffer;
                    using (InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream())
                    {
                        using (DataWriter dataWriter = new DataWriter(memoryStream))
                        {
                            dataWriter.WriteInt32(Encoding.UTF8.GetByteCount(userContent));
                            dataWriter.WriteString(userContent);
                            buffer = dataWriter.DetachBuffer();
                        }
                    }
                    await FileIO.WriteBufferAsync(file, buffer);
                    display.Text = "长度为 " + buffer.Length + " bytes 的文本信息写入到了文件 '" + file.Name + "':" + Environment.NewLine + Environment.NewLine + userContent;
                }
                catch (Exception exce)
                {
                    display.Text = "异常：" + exce.Message;
                }
            }
            else
            {
                display.Text = "请先创建文件";
            }
        }

        private async void Button_Click_6(object sender, RoutedEventArgs e)
        {
            IStorageFolder applicationFolder = ApplicationData.Current.LocalFolder;
            StorageFile file = await applicationFolder.GetFileAsync("text.dat");
            if (file != null)
            {
                try
                {
                    IBuffer buffer = await FileIO.ReadBufferAsync(file);
                    using (DataReader dataReader = DataReader.FromBuffer(buffer))
                    {
                        Int32 stringSize = dataReader.ReadInt32();
                        string fileContent = dataReader.ReadString((uint)stringSize);
                        display.Text = "长度为 " + buffer.Length + " bytes 的文本信息从文件 '" + file.Name + "'读取出来，其中字符床的长度为" + stringSize + " bytes :"
                             + fileContent;
                    }
                }
                catch (Exception exce)
                {
                    display.Text = "异常：" + exce.Message;
                }
            }
            else
            {
                display.Text = "请先创建文件";
            }
        }
    }
}
