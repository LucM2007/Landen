using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Landen.ViewModel
{
    internal class ContactInfoViewModel : ObservableObject
    {
        private string _naam;

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; OnPropertyChanged(); }
        }
        private string _telefoonnummer;

        public string Telefoonnummer
        {
            get { return _telefoonnummer; }
            set { _telefoonnummer = value; OnPropertyChanged(); }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        public ContactInfoViewModel()
        {
            _naam = "Luc";
            _telefoonnummer = "0612345678";
            _email = "ps252564@summacollege.nl";
        }

    }
}
