using Landen.Model;
using Landen.View;
using Landen.ViewModel;
using System.Configuration;
using System.Data;
using System.Runtime.Serialization.DataContracts;
using System.Windows;

namespace Landen
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UserMessage userMessage = new UserMessage();
            MainWindow = new MainView()
            {
                DataContext = new MainViewModel(userMessage)
            };
            MainWindow.Show();
        }
    }

}
