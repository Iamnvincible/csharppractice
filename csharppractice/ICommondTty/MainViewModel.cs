using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommondTty
{
    public class MainViewModel
    {
        public ICommand TestCommand { get; set; }
        public MainViewModel()
        {
            TestCommand=new RelayCommand()
        }

    }
}
