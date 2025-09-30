using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopanwendungTemperatur
{
    [Table("hersteller")]
    class ManufacturerModel : INotifyPropertyChanged
    {
        private int _id;
        private string _manufacturerName = string.Empty;
        private string _address = string.Empty;
        private string _phoneNumber = string.Empty;

        [Key]
        [Column("HerstellerId")]
        public int Id
        {
            get => _id; set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        [Column("Herstellername")]
        public string ManufacturerName
        {
            get => _manufacturerName; set
            {
                if (_manufacturerName != value)
                {
                    _manufacturerName = value;
                    OnPropertyChanged(nameof(ManufacturerName));
                }
            }
        }

        [Column("Adresse")]
        public string Address
        {
            get => _address; set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        [Column("Telefonnummer")]
        public string PhoneNumber
        {
            get => _phoneNumber; set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
