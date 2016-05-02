using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotify
{
    public class MainViewModel
    {
        public ObservableCollection<Student> students = new ObservableCollection<Student>();
        public MainViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                Student s = new Student { Age = i, Name = i.ToString() };
                students.Add(s);
            }
        }
    }
}
