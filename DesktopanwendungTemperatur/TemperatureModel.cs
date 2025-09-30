using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopanwendungTemperatur
{
    [Table("temperatur")]
    class TemperatureModel : INotifyPropertyChanged
    {
        private int _temperaturNumber;
        private double _temperaturValue;
        private DateTime _time;
        private int _sensorNumber;

        [Key]
        [Column("TemperaturNr")]
        public int TemperaturNumber
        {
            get => _temperaturNumber; set
            {
                if (_temperaturNumber != value)
                {
                    _temperaturNumber = value;
                    OnPropertyChanged(nameof(TemperaturNumber));
                }
            }
        }

        [Column("Temperaturwert")]
        public double TemperaturValue
        {
            get => _temperaturValue; set
            {
                if (_temperaturValue != value)
                {
                    _temperaturValue = value;
                    OnPropertyChanged(nameof(TemperaturValue));
                }
            }
        }

        [Column("Zeit")]
        public DateTime Time
        {
            get => _time; set
            {
                if (_time != value)
                {
                    _time = value;
                    OnPropertyChanged(nameof(Time));
                }
            }
        }

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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
