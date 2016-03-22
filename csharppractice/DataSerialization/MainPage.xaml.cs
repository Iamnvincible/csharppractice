using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
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

namespace DataSerialization
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            DateTime born = new DateTime(1955, 10, 28);
            int age = DateTime.Now.Year - born.Year-1 + ((DateTime.Now.Month >= born.Month && DateTime.Now.Day >= born.Day) ? 1 : 0);
            Student d = new Student(age,"Bill Gates");
            List<School> schools = new List<School>();
            schools.Add(new School("Harvard University", 1));
            schools.Add(new School(" Lakeside", 2));
            d.Education = schools;
            string jsonstr=d.GetJson();
            this.box.Text = jsonstr;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            string json= "{\"age\":\"233\",\"name\":\"Bill Gates\",\"education\":[{\"education\":{\"name\":\"Harvard University\",\"rank\":\"1\"}},{\"school\":{\"name\":\" Lakeside\",\"rank\":\"2\"}}]}";
            Student d = new Student(json);
            this.box.Text = $"{d.Age},{d.Name},{d.Education[0].Schoolname},{d.Education[1].Schoolname}";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            box.Text = "没写!";
        }

        private async void btn4_Click(object sender, RoutedEventArgs e)
        {
            NewtownJsonHelper n = new NewtownJsonHelper();
            List<Student> s = await n.ReadJsonSample();
            box.Text = $"转换成功,结果是这个{s.Count.ToString()}，过程看代码。";
        }
    }
}
