using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopanwendungTemperatur
{
    [Table("log")]
    class LogModel : INotifyPropertyChanged
    {

        private int _logId;
        private DateTime _date;
        private int _userId;
        private int _sensorNumber;

        [Key]
        [Column("LogId")]
        public int LogId
        {
            get => _logId; set
            {
                if (_logId != value)
                {
                    _logId = value;
                    OnPropertyChanged(nameof(LogId));
                }
            }
        }

        [Column("Datum")]
        public DateTime Date
        {
            get => _date; set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        [Column("NutzerId")]
        public int UserId
        {
            get => _userId; set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
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
