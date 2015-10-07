using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ICommondTty
{
    public class MainViewModel
    {
        public ICommand TestCommand { get; set; }
        public int SliderValue { get; set; }
        public MainViewModel()
        {
            SliderValue = 20;
            TestCommand = new RelayCommand(async para =>
              {
                  await new MessageDialog("你好"+SliderValue).ShowAsync();
              }
            );
        }

    }
}
