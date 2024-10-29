using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landen.Model
{
    [Table("Land")]
    [Index(nameof(Naam), nameof(EersteTaal), nameof(AantalInwooners), nameof(AantalInwoonersDatum), nameof(Hooftstad), nameof(TelefoonCode), nameof(Bnp), nameof(BnpDatum), nameof(Gevonden), IsUnique = true)]
    internal class Land : ObservableObject
    {
        [Key]
        public int id { get; set; }
        [Required,StringLength(255)]
        private string _naam { get; set; }
        [Required, StringLength(255)]
        private string _eersteTaal { get; set; }
        [Required, StringLength(255)]
        private int _aantalInwooners { get; set; }
        [Required, StringLength(255)]
        private DateTime _aantalInwoonersDatum { get; set; }
        [Required, StringLength(255)]
        private string _hooftstad { get; set; }
        [Required, StringLength(255)]
        private int _telefoonCode { get; set; }
        [Required, StringLength(255)]
        private decimal _bnp { get; set; }
        [Required, StringLength(255)]
        private DateTime _bnpDatum { get; set; }
        [Required, StringLength(255)]
        private DateTime _gevonden { get; set; }
        

        public string Naam
        {
            get { return _naam; }
            set { _naam = value; OnPropertyChanged(); }
        }
        public string EersteTaal
        {
            get { return _eersteTaal; }
            set { _eersteTaal = value; OnPropertyChanged(); }
        }

        public int AantalInwooners
        {
            get { return _aantalInwooners; }
            set { _aantalInwooners = value; OnPropertyChanged(); }
        }
        public DateTime AantalInwoonersDatum
        {
            get { return _aantalInwoonersDatum; }
            set { _aantalInwoonersDatum = value; OnPropertyChanged(); }
        }
        public string Hooftstad
        {
            get { return _hooftstad; }
            set { _hooftstad = value; OnPropertyChanged(); }
        }   
        public int TelefoonCode
        {
            get { return _telefoonCode; }
            set { _telefoonCode = value; OnPropertyChanged(); }
        }
        public decimal Bnp
        {
            get { return _bnp; }
            set { _bnp = value; OnPropertyChanged(); }
        }
        public DateTime BnpDatum
        {
            get { return _bnpDatum; }
            set { _bnpDatum = value; OnPropertyChanged(); }
        }
        public DateTime Gevonden
        {
            get { return _gevonden; }
            set { _gevonden = value; OnPropertyChanged(); }
        }
    }
}