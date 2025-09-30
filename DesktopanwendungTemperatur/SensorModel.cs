using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopanwendungTemperatur
{
    [Table("sensor")]
    class SensorModel : INotifyPropertyChanged
    {
        private int _sensorNumber;
        private string _address = string.Empty;
        private double _maxTemp;
        private string _serverRack = string.Empty;
        private int _manufacturerId;

        [Key]
        [Column("SensorNr")]
        public int SensorNumber
        {
            get => _sensorNumber; set
            {
                if (_sensorNumber != value)
                {
                    _sensorNumber = value;
                    OnPropertyChanged(nameof(SensorNumber));
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

        [Column("MaxTemp")]
        public double MaxTemp
        {
            get => _maxTemp; set
            {
                if (_maxTemp != value)
                {
                    _maxTemp = value;
                    OnPropertyChanged(nameof(MaxTemp));
                }
            }
        }

        [Column("Serverschrank")]
        public string ServerRack
        {
            get => _serverRack; set
            {
                if (_serverRack != value)
                {
                    _serverRack = value;
                    OnPropertyChanged(nameof(ServerRack));
                }
            }
        }

        [Column("HerstellerId")]
        public int ManufacturerId
        {
            get => _manufacturerId; set
            {
                if (_manufacturerId != value)
                {
                    _manufacturerId = value;
                    OnPropertyChanged(nameof(ManufacturerId));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
