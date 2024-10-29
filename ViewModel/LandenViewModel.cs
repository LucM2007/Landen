using Landen.Databases;
using Landen.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Landen.ViewModel
{
    internal class LandenViewModel : ObservableObject
    {
        #region fields

        private Land? _selectedLand;
        private Land _land;
        private UserMessage _userMessage;

        #endregion

        #region properties

        public ObservableCollection<Land> Landen { get; } = new ObservableCollection<Land>();

        public Land? SelectedLand
        {
            get { return _selectedLand; }
            set
            {
                if (_selectedLand != value)
                {
                    _selectedLand = value;
                    OnPropertyChanged();
                }
            }
        }

        public Land Land
        {
            get { return _land; }
            set
            {
                if (_land != value)
                {
                    _land = value;
                    OnPropertyChanged();
                }
            }
        }

        public LandenViewModel()
        {
            _land = new Land();
            _userMessage = new UserMessage();
            _land.Gevonden = DateTime.Now;

            AddLandCommand = new RelayCommand(ExecuteAddLandCommand, CanExecuteAddLandCommand);
            UpdateLandCommand = new RelayCommand(ExecuteUpdateLandCommand, CanExecuteUpdateLandCommand);
            DeleteLandCommand = new RelayCommand(ExecuteDeleteLandCommand, CanExecuteDeleteLandCommand);

            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var landenFromDb = db.Landen.ToList();
                    Landen.Clear();
                    foreach (var land in landenFromDb)
                    {
                        Landen.Add(land);
                    }
                }
            }
            catch (Exception Ex)
            {
                _userMessage.Text = Ex.InnerException == null ? Ex.Message : Ex.InnerException.Message;
            }
        }

        public LandenViewModel(UserMessage userMessage)
        {
            _land = new Land();
            _userMessage = userMessage;
            _land.Gevonden = DateTime.Now;

            AddLandCommand = new RelayCommand(ExecuteAddLandCommand, CanExecuteAddLandCommand);
            UpdateLandCommand = new RelayCommand(ExecuteUpdateLandCommand, CanExecuteUpdateLandCommand);
            DeleteLandCommand = new RelayCommand(ExecuteDeleteLandCommand, CanExecuteDeleteLandCommand);

            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    var landenFromDb = db.Landen.ToList();
                    Landen.Clear();
                    foreach (var land in landenFromDb)
                    {
                        Landen.Add(land);
                    }
                }
            }
            catch (Exception Ex)
            {
                _userMessage.Text = Ex.InnerException == null ? Ex.Message : Ex.InnerException.Message;
            }
        }

        #endregion

        #region commands

        public ICommand AddLandCommand { get; }
        public ICommand UpdateLandCommand { get; }
        public ICommand DeleteLandCommand { get; }

        public void ExecuteAddLandCommand(object? obj)
        {
            try
            {

                // Add the Land object to the collection
                Landen.Add(Land);

                using AppDbContext dbcontext = new AppDbContext();
                Land.id = 0; // Ensure the ID is set to 0 for a new entry
                dbcontext.Landen.Add(Land);
                dbcontext.SaveChanges();

                // Reset the Land object
                Land = new Land();
            }
            catch (Exception Ex)
            {
                // Log the exception (you can replace this with your logging mechanism)
                _userMessage.Text = Ex.InnerException == null ? Ex.Message : Ex.InnerException.Message;
            }
        }

        private bool CanExecuteAddLandCommand(object? arg)
        {
            return true;
        }

        public void ExecuteUpdateLandCommand(object? obj)
        {
            if (SelectedLand != null)
            {
                SelectedLand.Naam = Land.Naam;
                SelectedLand.EersteTaal = Land.EersteTaal;
                SelectedLand.AantalInwooners = Land.AantalInwooners;
                SelectedLand.AantalInwoonersDatum = Land.AantalInwoonersDatum;
                SelectedLand.Hooftstad = Land.Hooftstad;
                SelectedLand.TelefoonCode = Land.TelefoonCode;
                SelectedLand.Bnp = Land.Bnp;
                SelectedLand.BnpDatum = Land.BnpDatum;
                SelectedLand.Gevonden = Land.Gevonden;
                try
                {
                    using AppDbContext dbContext = new AppDbContext();
                    Land? DatabasesLand = dbContext.Landen.FirstOrDefault(x => x.id == SelectedLand.id);
                    if (DatabasesLand != null)
                    {
                        DatabasesLand.Naam = Land.Naam;
                        DatabasesLand.EersteTaal = Land.EersteTaal;
                        DatabasesLand.AantalInwooners = Land.AantalInwooners;
                        DatabasesLand.AantalInwoonersDatum = Land.AantalInwoonersDatum;
                        DatabasesLand.Hooftstad = Land.Hooftstad;
                        DatabasesLand.TelefoonCode = Land.TelefoonCode;
                        DatabasesLand.Bnp = Land.Bnp;
                        DatabasesLand.BnpDatum = Land.BnpDatum;
                        DatabasesLand.Gevonden = Land.Gevonden;

                        dbContext.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    _userMessage.Text = Ex.InnerException == null ? Ex.Message : Ex.InnerException.Message;
                }

                // Reset the Land object
                Land.Naam = string.Empty;
                Land.EersteTaal = string.Empty;
                Land.AantalInwooners = 0;
                Land.AantalInwoonersDatum = DateTime.MinValue;
                Land.Hooftstad = string.Empty;
                Land.TelefoonCode = 0;
                Land.Bnp = 0;
                Land.BnpDatum = DateTime.MinValue;
                Land.Gevonden = DateTime.MinValue;
            }
        }

        private bool CanExecuteUpdateLandCommand(object? arg)
        {
            return SelectedLand != null;
        }

        public void ExecuteDeleteLandCommand(object? obj)
        {
            if (obj is Land Landverwijderen)
            {
                Landen.Remove(Landverwijderen);
                try
                {
                    using AppDbContext dbContext = new AppDbContext();
                    Land? DatabasesLand = dbContext.Landen.FirstOrDefault(x => x.id == Landverwijderen.id);
                    if (DatabasesLand != null)
                    {
                        dbContext.Landen.Remove(DatabasesLand);
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception Ex)
                {
                    _userMessage.Text = Ex.InnerException == null ? Ex.Message : Ex.InnerException.Message;
                }
            }
        }

        private bool CanExecuteDeleteLandCommand(object? arg)
        {
            return arg is Land;
        }

        #endregion
    }
}
