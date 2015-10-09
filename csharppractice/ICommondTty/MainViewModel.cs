using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.UI.Popups;

namespace ICommondTty
{
    public class MainViewModel
    {
        public ICommand TestCommand { get; set; }
        public ICommand MainpulationCommand { get; set; }
        public int SliderValue { get; set; }
        public MainViewModel()
        {
            SliderValue = 20;
            TestCommand = new RelayCommand(async para =>
              {
                  await new MessageDialog("你好" + SliderValue).ShowAsync();
              }

            );
            MainpulationCommand = new RelayCommand(async para =>
            {
                Point p = (Point)para;
                if (p != null)
                    await new MessageDialog("你好" + p.X+"-"+p.Y).ShowAsync();
            });
        }

    }
}
