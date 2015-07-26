using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using XamlBrewer.Uwp.AdaptiveTriggerSample.ViewModels;

namespace XamlBrewer.Uwp.AdaptiveTriggerSample.Views
{
    public sealed partial class Shell : Page
    {
        public Shell()
        {
            this.InitializeComponent();

            // Navigate to the first page.
            var type = (DataContext as ShellViewModel).Menu.First().NavigationDestination;
            SplitViewFrame.Navigate(type);

            this.SizeChanged += Shell_SizeChanged;
        }

        // Update width indicator at bottom right of the screen.
        private void Shell_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            WidthIndicator.Text = "<- " + e.NewSize.Width.ToString() + " ->";
        }

        // Navigate to another page.
        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var menuItem = e.AddedItems.First() as MenuItem;
                if (menuItem.IsNavigation)
                {
                    SplitViewFrame.Navigate(menuItem.NavigationDestination);
                }
                else
                {
                    menuItem.Command.Execute(null);
                }
            }
        }

        // Swipe to open the splitview panel.
        private void SplitViewOpener_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X > 50)
            {
                MySplitView.IsPaneOpen = true;
            }
        }

        // Swipe to close the splitview panel.
        private void SplitViewPane_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Cumulative.Translation.X < -50)
            {
                MySplitView.IsPaneOpen = false;
            }
        }

        // Open or close the splitview panel through Hamburger button.
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }
    }
}
