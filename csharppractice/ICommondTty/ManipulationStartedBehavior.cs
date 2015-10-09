using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace ICommondTty
{
    public class ManipulationStartedBehavior
    {
        public static readonly DependencyProperty ManipulationStartedCommandProperty =
           DependencyProperty.RegisterAttached(
           "ManipulationStartedCommand",
            typeof(ICommand),
            typeof(ManipulationStartedBehavior),
            new PropertyMetadata(null, new PropertyChangedCallback(ManipulationStartedPropertyChangedCallback)));

        public static ICommand GetManipulationStartedCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(ManipulationStartedCommandProperty);
        }

        public static void SetManipulationStartedCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(ManipulationStartedCommandProperty, value);
        }

        private static void ManipulationStartedPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement ui = d as UIElement;
            if (ui != null)
            {
                ui.ManipulationStarted += ui_ManipulationStarted;
                ui.ManipulationCompleted += ui_ManipulationCompleted;
            }
        }

        static void ui_ManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        {

        }

        static void ui_ManipulationStarted(object sender, Windows.UI.Xaml.Input.ManipulationStartedRoutedEventArgs e)
        {
            GetManipulationStartedCommand(sender as UIElement).Execute(e.Position);
        }
    }
}
