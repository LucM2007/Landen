using Landen.Model;
using Landen.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Landen.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        #region fields
        private UserMessage _userMessage;
        private object _activeViewModel;
        #endregion

        #region constructors
        // Parameterless constructor for XAML instantiation
        public MainViewModel()
        {
            _userMessage = new UserMessage();
            InitializeCommands();
            _activeViewModel = new ContactInfoViewModel();
        }

        // Constructor with UserMessage parameter
        public MainViewModel(UserMessage userMessage)
        {
            _userMessage = userMessage;
            InitializeCommands();
        }

        #endregion

        #region properties
        // Exposing the entire UserMessage object for binding
        public UserMessage UserMessage => _userMessage;

        public object ActiveViewModel
        {
            get { return _activeViewModel; }
            set { _activeViewModel = value; OnPropertyChanged(); }
        }
        #endregion

        #region commands
        public ICommand ShowCommandInfoCommand { get; private set; }
        public ICommand ShowCommandLandenCommand { get; private set; }
        public ICommand ShowCommandStartCommand { get; private set; }
        #endregion

        #region methods
        private void InitializeCommands()
        {
            ShowCommandInfoCommand = new RelayCommand(ExecuteShowCommandInfo);
            ShowCommandLandenCommand = new RelayCommand(ExecuteShowCommandLanden);
        }

        private void ExecuteShowCommandInfo(object? obj)
        {
            ActiveViewModel = new ContactInfoViewModel();
        }

        private void ExecuteShowCommandLanden(object? obj)
        {
            ActiveViewModel = new LandenViewModel(_userMessage);
        }
        #endregion
    }
}
