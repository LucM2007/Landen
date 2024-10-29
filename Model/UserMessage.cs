using System.Windows.Threading;

namespace Landen.Model
{
    public class UserMessage : ObservableObject  // Change from 'internal' to 'public'
    {
        private string _text = string.Empty;
        private DispatcherTimer _timer;

        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(); StartDispatcherTimer(); }
        }

        public UserMessage()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(20);
            _timer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object? sender, EventArgs e)
        {
            Text = string.Empty;
            _timer.Stop();
        }

        private void StartDispatcherTimer()
        {
            _timer.Start();
        }
    }
}
